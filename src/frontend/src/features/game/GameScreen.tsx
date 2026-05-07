import React from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import { DndContext, useSensor, useSensors, PointerSensor } from '@dnd-kit/core';
import type { DragEndEvent } from '@dnd-kit/core';
import { mockLevels } from '../../data/mockData';
import { ChevronLeft } from 'lucide-react';
import InventorySidebar from './InventorySidebar';
import CraftingCanvas from './CraftingCanvas';
import { useGameStore } from './gameStore';

const GameScreen: React.FC = () => {
  const { levelId } = useParams<{ levelId: string }>();
  const navigate = useNavigate();
  const { addItem, updateItemPosition, canvasItems } = useGameStore();

  const level = mockLevels.find((l) => l.id === levelId);

  const sensors = useSensors(
    useSensor(PointerSensor, {
      activationConstraint: {
        distance: 5,
      },
    })
  );

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over, delta } = event;

    if (!over || over.id !== 'crafting-canvas') return;

    const data = active.data.current;
    if (!data) return;

    if (data.type === 'inventory') {
      // Logic for dropping a new item from inventory
      // We need to estimate where it was dropped relative to the canvas
      // Since it's a fixed-layout grid, we can use the cursor position if available, 
      // but simpler is to use a fixed offset from the drop point or 
      // handle it via a better coordinate system.
      // For now, let's place it at a reasonable default offset from the center or absolute pos.
      const x = 250 + delta.x;
      const y = 250 + delta.y;
      addItem(data.name, x, y);
    } else if (data.type === 'canvas') {
      // Logic for moving an existing item on the canvas
      const item = canvasItems.find((i) => i.id === data.originId);
      if (item) {
        updateItemPosition(item.id, item.x + delta.x, item.y + delta.y);
      }
    }
  };

  if (!level) {
    return (
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex flex-col items-center justify-center p-8">
        <div className="text-center">
          <h1 className="text-3xl font-bold mb-4">Level Not Found</h1>
          <p className="text-zinc-400 mb-8">The level you are looking for does not exist.</p>
          <button
            onClick={() => navigate('/')}
            className="px-6 py-2 bg-zinc-100 text-zinc-950 font-semibold rounded-lg hover:bg-zinc-300 transition-colors"
          >
            Back to Levels
          </button>
        </div>
      </div>
    );
  }

  return (
    <DndContext sensors={sensors} onDragEnd={handleDragEnd}>
      <div className="h-screen flex flex-col bg-zinc-950 text-zinc-100 overflow-hidden">
        {/* Header */}
        <header className="h-16 border-b border-zinc-800 bg-zinc-900/50 flex items-center justify-between px-6 shrink-0 z-20">
          <div className="flex items-center gap-4">
            <Link 
              to="/" 
              className="p-2 hover:bg-zinc-800 rounded-lg transition-colors text-zinc-400 hover:text-zinc-100"
              title="Back to Levels"
            >
              <ChevronLeft size={20} />
            </Link>
            <div>
              <h1 className="text-lg font-bold leading-tight">{level.name}</h1>
              <p className="text-xs text-zinc-500 uppercase tracking-wider font-semibold">Mission</p>
            </div>
          </div>

          <div className="bg-zinc-800 px-4 py-2 rounded-lg border border-zinc-700 flex items-center gap-3">
            <span className="text-xs text-zinc-400 font-medium">Goal:</span>
            <span className="text-sm font-bold text-blue-400">{level.goalItem}</span>
          </div>

          <div className="w-10 h-10 rounded-full bg-zinc-800 border border-zinc-700 flex items-center justify-center text-xs font-bold">
            JS
          </div>
        </header>

        {/* Main Content Area */}
        <main className="flex-1 flex overflow-hidden">
          <InventorySidebar items={level.startingItems} />
          <CraftingCanvas />
          <aside className="w-80 border-l border-zinc-800 bg-zinc-900/30 flex flex-col">
            <div className="p-4 border-b border-zinc-800 bg-zinc-900/50">
              <h2 className="text-sm font-semibold text-zinc-400 uppercase tracking-tight">Companion AI</h2>
            </div>
            <div className="flex-1 p-4 flex flex-col justify-end">
              <div className="mb-4 p-3 bg-zinc-800/50 rounded-lg border border-zinc-700/50 text-sm text-zinc-400 italic">
                Companion Chat Panel Placeholder
              </div>
              <div className="h-10 bg-zinc-800 rounded-md border border-zinc-700 px-3 flex items-center text-zinc-500 text-xs">
                Type a message...
              </div>
            </div>
          </aside>
        </main>
      </div>
    </DndContext>
  );
};

export default GameScreen;
