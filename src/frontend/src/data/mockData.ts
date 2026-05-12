export interface Level {
  id: string;
  name: string;
  goalItem: string;
  startingItems: string[];
}

export interface Item {
  name: string;
  emoji: string;
}

export const itemData: Record<string, string> = {
  'Water': '💧',
  'Fire': '🔥',
  'Earth': '🌱',
  'Air': '💨',
  'Steam': '♨️',
  'Mud': '🌫️',
  'Rain': '🌧️',
  'Dust': '🌪️',
  'Lava': '🌋',
  'Stone': '🪨',
};

export const mockLevels: Level[] = [
  {
    id: '1',
    name: 'Level 1: The Basics',
    goalItem: 'Steam',
    startingItems: ['Water', 'Fire', 'Earth', 'Air'],
  },
  {
    id: '2',
    name: 'Level 2: Muddy Waters',
    goalItem: 'Mud',
    startingItems: ['Water', 'Fire', 'Earth', 'Air'],
  },
  {
    id: '3',
    name: 'Level 3: Tropical Storm',
    goalItem: 'Rain',
    startingItems: ['Water', 'Fire', 'Earth', 'Air'],
  },
];
