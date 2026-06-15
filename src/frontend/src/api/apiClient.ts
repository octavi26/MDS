import {
  describeError,
  emitStartupDebug,
  getApiBaseUrl,
} from '../debug/startupDebug';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5088';
const USER_ID_STORAGE_KEY = 'mock_forge_user_id';
const USERNAME_STORAGE_KEY = 'mock_forge_username';

export interface Level {
  id: string;
  name: string;
  description: string;
  difficulty: number;
  goalItem: string;
  startingItems: string[];
  isCompleted: boolean;
  isLocked: boolean;
}

export interface Session {
  sessionId: string;
}

export interface SessionDetail {
  id: string;
  levelId: string;
  inventory: { name: string; quantity: number }[];
}

export interface CraftedElement {
  name: string;
  description: string;
  icon: string;
  isGoalReached?: boolean;
}

export interface User {
  id: string;
  username: string;
}

class ApiRequestError extends Error {
  readonly status: number;
  readonly statusText: string;
  readonly url: string;
  readonly body: string;

  constructor(
    message: string,
    status: number,
    statusText: string,
    url: string,
    body: string,
  ) {
    super(message);
    this.name = 'ApiRequestError';
    this.status = status;
    this.statusText = statusText;
    this.url = url;
    this.body = body;
  }
}

function getStoredValue(key: string): string | null {
  const value = localStorage.getItem(key);
  if (!value || value === 'undefined' || value === 'null') return null;
  return value;
}

async function ensureOk(response: Response, label: string): Promise<void> {
  if (response.ok) return;

  const body = await response.text();
  throw new ApiRequestError(
    `${label} failed with HTTP ${response.status} ${response.statusText}`,
    response.status,
    response.statusText,
    response.url,
    body.slice(0, 1000),
  );
}

async function fetchJson<T>(
  label: string,
  url: string,
  init?: RequestInit,
): Promise<T> {
  emitStartupDebug(label, 'pending', `Requesting ${url}`);

  try {
    const response = init ? await fetch(url, init) : await fetch(url);
    emitStartupDebug(label, 'info', `Response ${response.status} ${response.statusText}`, url);
    await ensureOk(response, label);
    const payload = await response.json();
    emitStartupDebug(label, 'success', 'Request completed');
    return payload;
  } catch (error) {
    emitStartupDebug(label, 'error', describeError(error), error instanceof ApiRequestError
      ? `URL: ${error.url}\nStatus: ${error.status} ${error.statusText}\nBody: ${error.body || '(empty)'}`
      : undefined);
    throw error;
  }
}

export const apiClient = {
  getApiBaseUrl(): string {
    return getApiBaseUrl();
  },

  getUserId(): string | null {
    return getStoredValue(USER_ID_STORAGE_KEY);
  },

  getUsername(): string | null {
    return getStoredValue(USERNAME_STORAGE_KEY);
  },

  async registerUser(username: string): Promise<User> {
    const user = await fetchJson<User>('register user', `${API_BASE_URL}/api/users/register`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username }),
    });
    localStorage.setItem(USER_ID_STORAGE_KEY, user.id);
    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
    return user;
  },

  async getLevels(): Promise<Level[]> {
    const userId = getStoredValue(USER_ID_STORAGE_KEY);
    const url = userId ? `${API_BASE_URL}/api/levels?userId=${userId}` : `${API_BASE_URL}/api/levels`;
    return fetchJson<Level[]>('load levels', url);
  },

  async startSession(userId: string, levelId: string): Promise<Session> {
    return fetchJson<Session>('start session', `${API_BASE_URL}/api/sessions/start`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ userId, levelId }),
    });
  },

  async getSession(sessionId: string): Promise<SessionDetail> {
    return fetchJson<SessionDetail>('load session', `${API_BASE_URL}/api/sessions/${sessionId}`);
  },

  async craft(sessionId: string, elementA: string, elementB: string): Promise<CraftedElement> {
    return fetchJson<CraftedElement>('craft element', `${API_BASE_URL}/api/craft`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ sessionId, elementA, elementB }),
    });
  }
};
