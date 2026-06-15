import { useEffect, useState } from 'react';
import {
  getApiBaseUrl,
  isStartupDebugEnabled,
  subscribeStartupDebug,
  type StartupDebugEntry,
} from './startupDebug';

const statusClassNames: Record<StartupDebugEntry['status'], string> = {
  info: 'border-zinc-600 text-zinc-300',
  pending: 'border-amber-500 text-amber-300',
  success: 'border-emerald-500 text-emerald-300',
  error: 'border-red-500 text-red-300',
};

export default function StartupDebugPanel() {
  const [enabled] = useState(() => isStartupDebugEnabled());
  const [entries, setEntries] = useState<StartupDebugEntry[]>([]);

  useEffect(() => {
    if (!enabled) return;

    return subscribeStartupDebug(setEntries);
  }, [enabled]);

  if (!enabled) return null;

  return (
    <aside className="fixed bottom-4 right-4 z-[100] w-[min(92vw,520px)] max-h-[70vh] overflow-hidden rounded-2xl border border-orange-500/30 bg-zinc-950/95 text-zinc-100 shadow-[0_0_60px_rgba(0,0,0,0.7)] backdrop-blur-xl">
      <div className="border-b border-white/10 px-4 py-3">
        <div className="flex items-center justify-between gap-4">
          <h2 className="text-xs font-black uppercase tracking-[0.25em] text-orange-400">
            Startup Debug
          </h2>
          <span className="rounded-full border border-orange-500/30 px-2 py-1 text-[10px] font-black uppercase tracking-widest text-orange-300">
            debug=1
          </span>
        </div>
        <p className="mt-2 break-all text-[11px] font-mono text-zinc-400">
          API: {getApiBaseUrl()}
        </p>
      </div>

      <div className="max-h-[54vh] overflow-y-auto p-3">
        {entries.length === 0 ? (
          <p className="p-3 text-xs font-medium text-zinc-500">
            Waiting for startup events...
          </p>
        ) : (
          <ol className="space-y-2">
            {entries.map((entry) => (
              <li
                key={entry.id}
                className={`rounded-xl border bg-white/[0.03] p-3 ${statusClassNames[entry.status]}`}
              >
                <div className="flex flex-wrap items-center justify-between gap-2">
                  <span className="text-[10px] font-black uppercase tracking-[0.2em]">
                    {entry.phase}
                  </span>
                  <span className="font-mono text-[10px] text-zinc-500">
                    {entry.timestamp}
                  </span>
                </div>
                <p className="mt-2 text-xs font-bold text-zinc-100">
                  {entry.message}
                </p>
                {entry.detail && (
                  <pre className="mt-2 max-h-32 overflow-auto whitespace-pre-wrap break-words rounded-lg bg-black/40 p-2 font-mono text-[10px] leading-relaxed text-zinc-300">
                    {entry.detail}
                  </pre>
                )}
              </li>
            ))}
          </ol>
        )}
      </div>
    </aside>
  );
}
