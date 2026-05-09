const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5088';

export interface Level {
  id: string;
  name: string;
  description: string;
  difficulty: number;
  goalItem: string;
  startingItems: string[];
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
}

export const apiClient = {
  async getLevels(): Promise<Level[]> {
    const response = await fetch(`${API_BASE_URL}/api/levels`);
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
  },

  async getCompanionComment(eventType: string, elementNames: string[]): Promise<{ comment: string }> {
    const response = await fetch(`${API_BASE_URL}/api/companion/comments`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ eventType, elementNames }),
    });
    if (!response.ok) throw new Error('Failed to fetch companion comment');
    return response.json();
  },
};
