import React from 'react';
import { Trash2 } from 'lucide-react';

const CraftingCanvas: React.FC = () => {
  const handleClearCanvas = () => {
    console.log('Canvas cleared');
  };

  return (
    <section className="flex-1 relative bg-[radial-gradient(#27272a_1px,transparent_1px)] [background-size:32px_32px] bg-zinc-950 flex flex-col overflow-hidden">
      {/* Workspace Watermark */}
      <div className="absolute inset-0 flex items-center justify-center pointer-events-none opacity-[0.03] select-none">
        <div className="flex flex-col items-center">
          <div className="w-64 h-64 border-[12px] border-zinc-100 rounded-full flex items-center justify-center">
            <span className="text-8xl font-black">C</span>
          </div>
          <span className="mt-8 text-4xl font-bold tracking-[1em] uppercase">Laboratory</span>
        </div>
      </div>

      {/* Canvas Header/Breadcrumb area */}
      <div className="p-4 flex items-center justify-between pointer-events-none z-10">
        <span className="text-[10px] font-mono text-zinc-600 uppercase tracking-widest bg-zinc-900/50 px-2 py-1 rounded border border-zinc-800">
          workspace_v1.0
        </span>
      </div>

      {/* Main interaction area (Visual Only) */}
      <div className="flex-1 flex items-center justify-center">
        <div className="text-center opacity-40 select-none animate-pulse">
          <p className="text-sm font-medium text-zinc-500 uppercase tracking-widest">
            Drop items here to start crafting
          </p>
        </div>
      </div>

      {/* Floating Controls */}
      <div className="absolute bottom-6 right-6 flex flex-col gap-3">
        <button
          onClick={handleClearCanvas}
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
