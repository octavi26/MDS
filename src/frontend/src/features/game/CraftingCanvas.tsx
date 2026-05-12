import React from 'react';
import { useDroppable } from '@dnd-kit/core';
import { Trash2 } from 'lucide-react';
import { useGameStore } from './gameStore';
import DraggableItem from './DraggableItem';

const CraftingCanvas: React.FC = () => {
  const { setNodeRef } = useDroppable({
    id: 'crafting-canvas',
  });

  const { canvasItems, clearCanvas, cloneItem } = useGameStore();

  return (
    <section 
      ref={setNodeRef}
      // @ts-ignore - custom attribute for DOM lookup
      ref-id="crafting-canvas-container"
      className="flex-1 relative bg-[radial-gradient(#27272a_1px,transparent_1px)] [background-size:32px_32px] bg-zinc-950 flex flex-col overflow-hidden"
    >
      {/* Workspace Watermark */}
      <div className="absolute inset-0 flex items-center justify-center pointer-events-none opacity-[0.05] select-none">
        <div className="flex flex-col items-center">
          <div className="w-64 h-64 border-[12px] border-orange-500/30 rounded-full flex items-center justify-center">
            <span className="text-8xl font-black text-orange-600/30">M</span>
          </div>
          <span className="mt-8 text-4xl font-black tracking-[0.5em] uppercase text-orange-700/30">Mocking Forge</span>
        </div>
      </div>

      {/* Canvas Header */}
      <div className="p-4 flex items-center justify-between pointer-events-none z-10">
        <span className="text-[10px] font-mono text-orange-600/50 uppercase tracking-widest bg-orange-950/10 px-2 py-1 rounded border border-orange-900/20">
          forge_v1.0_active
        </span>
      </div>

      {/* Render Canvas Items */}
      <div className="flex-1 relative">
        {canvasItems.map((item, index) => (
          <DraggableItem
            key={item.id}
            id={item.id}
            name={item.name}
            type="canvas"
            className={index === 0 ? "animate-proximity-glow" : ""}
            style={{
              left: item.x,
              top: item.y,
            }}
            onDoubleClick={() => cloneItem(item.id)}
          />
        ))}

        {canvasItems.length === 0 && (
          <div className="absolute inset-0 flex items-center justify-center pointer-events-none">
            <div className="text-center opacity-40 select-none animate-pulse">
              <p className="text-sm font-medium text-zinc-500 uppercase tracking-widest">
                Drop items here to start crafting
              </p>
            </div>
          </div>
        )}
      </div>

      {/* Floating Controls */}
      <div className="absolute bottom-6 right-6 flex flex-col gap-3 z-30">
        <button
          onClick={clearCanvas}
          className="flex items-center gap-2 px-4 py-2 bg-zinc-900 border border-zinc-800 text-zinc-400 hover:text-red-400 hover:border-red-500/50 hover:bg-red-500/10 rounded-lg transition-all shadow-xl group active:scale-95"
        >
          <Trash2 size={18} className="group-hover:animate-bounce" />
          <span className="text-sm font-semibold">Clear Canvas</span>
        </button>
      </div>

      {/* Boundary indication */}
      <div className="absolute inset-4 border-2 border-dashed border-zinc-800/50 rounded-2xl pointer-events-none" />
    </section>
  );
};

export default CraftingCanvas;
