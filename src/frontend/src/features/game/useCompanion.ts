import { useCallback, useEffect, useRef, useState } from 'react';
import {
  requestCompanionComment,
  type CompanionCommentRequest,
  type CompanionEventType,
} from '../../api/companion';

interface UseCompanionInput {
  levelName?: string;
  goalName?: string;
  inventory: string[];
  /** When true, skip audio and reveal lines immediately. */
  muted?: boolean;
}

interface UseCompanionResult {
  message: string | null;
  notifyElementAdded: (elementName: string) => void;
  notifyCanvasCleared: () => void;
}

/**
 * Owns the companion's current spoken line and translates gameplay events into
 * calls to POST /api/companion/comments. When a comment includes a voice line,
 * we hold the text back until the audio actually starts playing — that sync
 * makes the (slightly delayed) speech feel real-time instead of laggy. Failures
 * are swallowed so the UI never blocks on an unreachable backend or audio.
 */
export const useCompanion = ({ levelName, goalName, inventory, muted = false }: UseCompanionInput): UseCompanionResult => {
  const [message, setMessage] = useState<string | null>(null);
  const discoveredRef = useRef<Set<string>>(new Set());
  const moveCountRef = useRef(0);
  const inFlightRef = useRef<AbortController | null>(null);
  const audioRef = useRef<HTMLAudioElement | null>(null);
  const mutedRef = useRef(muted);

  useEffect(() => {
    mutedRef.current = muted;
  }, [muted]);

  const stopAudio = useCallback(() => {
    if (audioRef.current) {
      audioRef.current.pause();
      audioRef.current.src = '';
      audioRef.current = null;
    }
  }, []);

  useEffect(
    () => () => {
      inFlightRef.current?.abort();
      stopAudio();
    },
    [stopAudio],
  );

  /**
   * Reveal the line in sync with its voice: show text the instant audio begins.
   * If there is no audio (muted, missing URL, autoplay blocked, or error) we
   * fall back to showing the text immediately so a line is never lost.
   */
  const speak = useCallback(
    (text: string, voiceLineUrl: string | null) => {
      stopAudio();

      if (mutedRef.current || !voiceLineUrl) {
        setMessage(text);
        return;
      }

      const audio = new Audio(voiceLineUrl);
      audioRef.current = audio;

      let revealed = false;
      const reveal = () => {
        if (!revealed) {
          revealed = true;
          setMessage(text);
        }
      };

      audio.addEventListener('playing', reveal, { once: true });
      audio.addEventListener('error', reveal, { once: true });

      // Safety net: if 'playing' never fires (some browsers), reveal anyway.
      const fallback = window.setTimeout(reveal, 1500);
      audio.addEventListener('playing', () => window.clearTimeout(fallback), { once: true });

      void audio.play().catch(() => {
        // Autoplay blocked before the first user gesture — show text now.
        reveal();
      });
    },
    [stopAudio],
  );

  const send = useCallback(
    async (eventType: CompanionEventType, elementName: string | null) => {
      inFlightRef.current?.abort();
      const controller = new AbortController();
      inFlightRef.current = controller;

      const payload: CompanionCommentRequest = {
        eventType,
        elementName,
        levelName: levelName ?? null,
        goalName: goalName ?? null,
        inventory,
        moveCount: moveCountRef.current,
      };

      try {
        const comment = await requestCompanionComment(payload, { signal: controller.signal });
        if (controller.signal.aborted) return;
        if (comment) {
          speak(comment.text, comment.voiceLineUrl ?? null);
        }
      } catch {
        // AbortError or unexpected — silently drop.
      }
    },
    [goalName, inventory, levelName, speak],
  );

  const notifyElementAdded = useCallback(
    (elementName: string) => {
      moveCountRef.current += 1;

      const isGoal = goalName !== undefined && goalName !== null && elementName === goalName;
      const isFirst = !discoveredRef.current.has(elementName);
      discoveredRef.current.add(elementName);

      if (isGoal) {
        void send('LevelCompleted', elementName);
        return;
      }

      if (isFirst) {
        void send('FirstDiscovery', elementName);
      }
    },
    [goalName, send],
  );

  const notifyCanvasCleared = useCallback(() => {
    moveCountRef.current += 1;
    discoveredRef.current.clear();
    void send('FailedCombination', null);
  }, [send]);

  return { message, notifyElementAdded, notifyCanvasCleared };
};
