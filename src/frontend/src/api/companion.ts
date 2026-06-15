export type CompanionEventType =
  | 'ImportantElementDiscovered'
  | 'LevelCompleted'
  | 'FirstDiscovery'
  | 'FailedCombination';

export interface CompanionCommentRequest {
  eventType: CompanionEventType;
  elementName?: string | null;
  levelName?: string | null;
  goalName?: string | null;
  inventory: string[];
  moveCount: number;
  /** Consecutive unproductive attempts; the companion starts hinting once this climbs. */
  struggleCount?: number;
}

export interface CompanionComment {
  text: string;
  eventType: CompanionEventType;
  source: string;
  voiceLineUrl?: string | null;
}

const DEFAULT_BASE_URL = 'http://localhost:5088';

const resolveBaseUrl = (): string => {
  const fromEnv = import.meta.env?.VITE_API_BASE_URL;
  return typeof fromEnv === 'string' && fromEnv.length > 0 ? fromEnv : DEFAULT_BASE_URL;
};

export const requestCompanionComment = async (
  request: CompanionCommentRequest,
  options: { signal?: AbortSignal; baseUrl?: string } = {},
): Promise<CompanionComment | null> => {
  const baseUrl = options.baseUrl ?? resolveBaseUrl();
  const url = `${baseUrl.replace(/\/$/, '')}/api/companion/comments`;

  try {
    const response = await fetch(url, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(request),
      signal: options.signal,
    });

    if (!response.ok) {
      return null;
    }

    const payload = (await response.json()) as CompanionComment;
    if (!payload || typeof payload.text !== 'string' || payload.text.length === 0) {
      return null;
    }
    return payload;
  } catch (error) {
    if ((error as { name?: string }).name === 'AbortError') {
      throw error;
    }
    return null;
  }
};
