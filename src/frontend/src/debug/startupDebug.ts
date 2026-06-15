export type StartupDebugStatus = 'info' | 'pending' | 'success' | 'error';

export interface StartupDebugEntry {
  id: string;
  timestamp: string;
  phase: string;
  status: StartupDebugStatus;
  message: string;
  detail?: string;
}

const DEBUG_STORAGE_KEY = 'mock_forge_debug';
const MAX_ENTRIES = 30;
const listeners = new Set<(entries: StartupDebugEntry[]) => void>();
let entries: StartupDebugEntry[] = [];

export function getApiBaseUrl(): string {
  return import.meta.env.VITE_API_BASE_URL || 'http://localhost:5088';
}

export function isStartupDebugEnabled(): boolean {
  if (typeof window === 'undefined') return false;

  const params = new URLSearchParams(window.location.search);
  const debugParam = params.get('debug') ?? params.get('forgeDebug');
  const storage = window.localStorage;

  if (debugParam === '1' || debugParam === 'true') {
    storage?.setItem(DEBUG_STORAGE_KEY, '1');
    return true;
  }

  if (debugParam === '0' || debugParam === 'false') {
    storage?.removeItem(DEBUG_STORAGE_KEY);
    return false;
  }

  return storage?.getItem(DEBUG_STORAGE_KEY) === '1';
}

export function emitStartupDebug(
  phase: string,
  status: StartupDebugStatus,
  message: string,
  detail?: string,
): void {
  if (!isStartupDebugEnabled()) return;

  entries = [
    {
      id: `${Date.now()}-${Math.random()}`,
      timestamp: new Date().toLocaleTimeString(),
      phase,
      status,
      message,
      detail,
    },
    ...entries,
  ].slice(0, MAX_ENTRIES);

  for (const listener of listeners) {
    listener(entries);
  }
}

export function subscribeStartupDebug(
  listener: (entries: StartupDebugEntry[]) => void,
): () => void {
  listeners.add(listener);
  listener(entries);

  return () => {
    listeners.delete(listener);
  };
}

export function describeError(error: unknown): string {
  if (error instanceof Error) {
    return error.message;
  }

  try {
    return JSON.stringify(error);
  } catch {
    return String(error);
  }
}
