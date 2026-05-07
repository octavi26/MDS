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
}

interface UseCompanionResult {
  message: string | null;
  notifyElementAdded: (elementName: string) => void;
  notifyCanvasCleared: () => void;
}

/**
 * Owns the companion's current spoken line and translates gameplay events into
 * calls to POST /api/companion/comments. Failures are swallowed so the UI never
 * blocks on an unreachable backend.
 */
export const useCompanion = ({ levelName, goalName, inventory }: UseCompanionInput): UseCompanionResult => {
  const [message, setMessage] = useState<string | null>(null);
  const discoveredRef = useRef<Set<string>>(new Set());
  const moveCountRef = useRef(0);
  const inFlightRef = useRef<AbortController | null>(null);

  useEffect(() => () => inFlightRef.current?.abort(), []);

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
          setMessage(comment.text);
        }
      } catch {
        // AbortError or unexpected — silently drop.
      }
    },
    [goalName, inventory, levelName],
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
