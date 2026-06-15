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

function getStoredValue(key: string): string | null {
  const value = localStorage.getItem(key);
  if (!value || value === 'undefined' || value === 'null') return null;
  return value;
}

export const apiClient = {
  getUserId(): string | null {
    return getStoredValue(USER_ID_STORAGE_KEY);
  },

  getUsername(): string | null {
    return getStoredValue(USERNAME_STORAGE_KEY);
  },

  async registerUser(username: string): Promise<User> {
    const response = await fetch(`${API_BASE_URL}/api/users/register`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username }),
    });
    if (!response.ok) throw new Error('Failed to register user');
    const user = await response.json();
    localStorage.setItem(USER_ID_STORAGE_KEY, user.id);
    localStorage.setItem(USERNAME_STORAGE_KEY, user.username);
    return user;
  },

  async getLevels(): Promise<Level[]> {
    const userId = getStoredValue(USER_ID_STORAGE_KEY);
    const url = userId ? `${API_BASE_URL}/api/levels?userId=${userId}` : `${API_BASE_URL}/api/levels`;
    const response = await fetch(url);
    if (!response.ok) throw new Error('Failed to fetch levels');
    return response.json();
  },

  async startSession(userId: string, levelId: string): Promise<Session> {
    const response = await fetch(`${API_BASE_URL}/api/sessions/start`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ userId, levelId }),
    });
    if (!response.ok) throw new Error('Failed to start session');
    return response.json();
  },

  async getSession(sessionId: string): Promise<SessionDetail> {
    const response = await fetch(`${API_BASE_URL}/api/sessions/${sessionId}`);
    if (!response.ok) throw new Error('Failed to fetch session');
    return response.json();
  },

  async craft(sessionId: string, elementA: string, elementB: string): Promise<CraftedElement> {
    const response = await fetch(`${API_BASE_URL}/api/craft`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ sessionId, elementA, elementB }),
    });
    if (!response.ok) throw new Error('Failed to craft element');
    return response.json();
  }
};
