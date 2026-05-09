import { create } from 'zustand';

export interface CanvasItem {
  id: string;
  name: string;
  x: number;
  y: number;
}

interface GameState {
  canvasItems: CanvasItem[];
  addItem: (name: string, x: number, y: number) => void;
  updateItemPosition: (id: string, x: number, y: number) => void;
  combineItems: (sourceId: string, targetId: string, resultName: string, x: number, y: number) => void;
  clearCanvas: () => void;
  cloneItem: (id: string) => void;
}

export const useGameStore = create<GameState>((set) => ({
  canvasItems: [],
  
  addItem: (name, x, y) => set((state) => ({
    canvasItems: [
      ...state.canvasItems,
      { id: `${name}-${Date.now()}-${Math.random()}`, name, x, y }
    ]
  })),

  updateItemPosition: (id, x, y) => set((state) => ({
    canvasItems: state.canvasItems.map((item) => 
      item.id === id ? { ...item, x, y } : item
    )
  })),

  combineItems: (sourceId, targetId, resultName, x, y) => set((state) => ({
    canvasItems: [
      ...state.canvasItems.filter((item) => item.id !== sourceId && item.id !== targetId),
      { id: `${resultName}-${Date.now()}-${Math.random()}`, name: resultName, x, y }
    ]
  })),

  clearCanvas: () => set({ canvasItems: [] }),

  cloneItem: (id) => set((state) => {
    const item = state.canvasItems.find((i) => i.id === id);
    if (!item) return state;
    return {
      canvasItems: [
        ...state.canvasItems,
        { 
          id: `${item.name}-${Date.now()}-${Math.random()}`, 
          name: item.name, 
          x: item.x + 20, 
          y: item.y + 20 
        }
      ]
    };
  }),
}));
