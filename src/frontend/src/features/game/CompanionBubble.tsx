import React, { useEffect, useState } from 'react';

interface CompanionBubbleProps {
  message?: string | null;
  /** Auto-fade in milliseconds. Set to 0 or omit to keep the bubble visible. */
  visibleForMs?: number;
}

/**
 * A floating, read-only AI companion mascot that displays messages to the player.
 * When a new message arrives, the bubble appears and (optionally) fades away after
 * `visibleForMs`. Re-rendering with the same message does not reset the timer.
 */
const CompanionBubble: React.FC<CompanionBubbleProps> = ({ message, visibleForMs = 6000 }) => {
  const [visibleMessage, setVisibleMessage] = useState<string | null>(null);

  useEffect(() => {
    if (!message) {
      setVisibleMessage(null);
      return;
    }

    setVisibleMessage(message);

    if (visibleForMs <= 0) {
      return;
    }

    const timer = window.setTimeout(() => {
      setVisibleMessage((current) => (current === message ? null : current));
    }, visibleForMs);

    return () => window.clearTimeout(timer);
  }, [message, visibleForMs]);

  return (
    <div className="flex flex-col items-end gap-3 animate-float pointer-events-none select-none">
      {visibleMessage && (
        <div
          role="status"
          aria-live="polite"
          className="relative bg-zinc-100 text-zinc-900 p-4 rounded-2xl rounded-br-none shadow-2xl max-w-[280px] border border-white/20 backdrop-blur-sm"
        >
          <p className="text-sm font-semibold leading-relaxed tracking-tight">
            {visibleMessage}
          </p>
          {/* Bubble Tail - a simple triangle using clip-path */}
          <div
            className="absolute -bottom-2 right-0 w-4 h-4 bg-zinc-100"
            style={{ clipPath: 'polygon(0 0, 100% 0, 100% 100%)' }}
          />
        </div>
      )}

      {/* Avatar - a snarky robot/wizard */}
      <div className="w-14 h-14 bg-gradient-to-br from-zinc-800 to-zinc-950 rounded-full border-2 border-zinc-700 flex items-center justify-center text-3xl shadow-xl ring-4 ring-zinc-900/50 transition-transform duration-300 hover:scale-110">
        <span className="drop-shadow-md">🤖</span>
      </div>
    </div>
  );
};

export default CompanionBubble;
