import React from 'react';
import { useDroppable } from '@dnd-kit/core';
import { Trash2, Flame, Hammer } from 'lucide-react';
import { motion } from 'framer-motion';
import { useGameStore } from './gameStore';
import DraggableItem from './DraggableItem';

interface CraftingCanvasProps {
  hoveredTargetId?: string | null;
  canvasRef?: React.RefObject<HTMLDivElement | null>;
}

const CraftingCanvas: React.FC<CraftingCanvasProps> = ({ hoveredTargetId, canvasRef }) => {
  const { setNodeRef } = useDroppable({
    id: 'crafting-canvas',
  });

  const { canvasItems, clearCanvas, cloneItem } = useGameStore();

  return (
    <section 
      ref={setNodeRef}
      className="flex-1 relative flex flex-col overflow-hidden bg-[#0c0a09] scanline-container"
    >
      {/* ... rest of background decor ... */}
      <div className="absolute inset-0 bg-[radial-gradient(circle_at_center,rgba(220,38,38,0.15)_0%,transparent_80%)] animate-ember-pulse" />
      
      <div className="absolute inset-0 opacity-20 pointer-events-none overflow-hidden">
        <div className="absolute inset-0 forgery-grid" />
        <svg className="absolute inset-0 w-full h-full text-orange-500/20" xmlns="http://www.w3.org/2000/svg">
          <pattern id="circuit" x="0" y="0" width="200" height="200" patternUnits="userSpaceOnUse">
            <path d="M0 100 h40 m20 0 h80 m20 0 h40 M100 0 v40 m0 20 v80 m0 20 v40" fill="none" stroke="currentColor" strokeWidth="0.5" />
            <circle cx="40" cy="100" r="2" fill="currentColor" />
            <circle cx="160" cy="100" r="2" fill="currentColor" />
            <circle cx="100" cy="40" r="2" fill="currentColor" />
            <circle cx="100" cy="160" r="2" fill="currentColor" />
          </pattern>
          <rect width="100%" height="100%" fill="url(#circuit)" />
        </svg>
      </div>

      <div className="absolute inset-0 pointer-events-none overflow-hidden">
        <motion.div 
          animate={{ x: ['-100%', '100%'] }}
          transition={{ duration: 10, repeat: Infinity, ease: "linear" }}
          className="absolute top-0 left-0 w-full h-px bg-gradient-to-r from-transparent via-orange-500 to-transparent opacity-30"
        />
        <motion.div 
          animate={{ y: ['-100%', '100%'] }}
          transition={{ duration: 15, repeat: Infinity, ease: "linear" }}
          className="absolute top-0 right-0 h-full w-px bg-gradient-to-b from-transparent via-red-500 to-transparent opacity-30"
        />
      </div>

      <div className="absolute inset-0 flex items-center justify-center pointer-events-none select-none overflow-hidden">
        <motion.div 
          initial={{ opacity: 0, scale: 0.8 }}
          animate={{ opacity: 0.05, scale: 1 }}
          transition={{ duration: 2 }}
          className="flex flex-col items-center relative"
        >
          <div className="w-[600px] h-[600px] border-[1px] border-orange-500/20 rounded-full flex items-center justify-center">
            <div className="w-[500px] h-[500px] border-[10px] border-white/5 rounded-full flex items-center justify-center animate-[spin_60s_linear_infinite]">
              <Flame size={300} strokeWidth={0.5} className="text-orange-600/50" />
            </div>
          </div>
          <div className="absolute bottom-20 flex flex-col items-center">
            <span className="text-8xl font-black tracking-[1.5em] uppercase text-white/5">Forge</span>
            <span className="text-[10px] font-black tracking-[0.8em] uppercase text-orange-500/40">Advanced Synthesis Matrix</span>
          </div>
        </motion.div>
      </div>

      <div className="p-8 flex items-start justify-between pointer-events-none z-10">
        <div className="space-y-4">
          <div className="flex flex-col gap-1">
            <div className="flex items-center gap-2">
              <div className="w-2 h-2 rounded-full bg-orange-500 animate-ping" />
              <span className="text-[10px] font-black text-orange-500 uppercase tracking-[0.4em]">Matrix: Stabilized</span>
            </div>
            <div className="flex gap-1 mt-1">
              {[...Array(8)].map((_, i) => (
                <div key={i} className="h-1.5 w-6 bg-zinc-900 border border-white/5 rounded-sm overflow-hidden">
                  <motion.div 
                    animate={{ x: [-24, 24] }}
                    transition={{ duration: 1.5, repeat: Infinity, ease: "easeInOut", delay: i * 0.1 }}
                    className="h-full w-full bg-gradient-to-r from-transparent via-orange-500 to-transparent"
                  />
                </div>
              ))}
            </div>
          </div>
          
          <div className="flex flex-col gap-1 opacity-60">
            <span className="text-[8px] font-bold text-zinc-500 uppercase tracking-[0.2em]">Temp Profile</span>
            <div className="h-32 w-1.5 bg-zinc-900/50 border border-white/5 rounded-full relative overflow-hidden">
              <motion.div 
                animate={{ height: ['20%', '60%', '40%', '80%', '50%'] }}
                transition={{ duration: 4, repeat: Infinity, ease: "easeInOut" }}
                className="absolute bottom-0 w-full bg-gradient-to-t from-red-600 via-orange-500 to-yellow-400"
              />
            </div>
          </div>
        </div>

        <div className="text-right space-y-2">
          <div className="text-[10px] font-black text-zinc-500 uppercase tracking-widest">Zone: Sector_04</div>
          <div className="text-[8px] font-mono text-orange-500/50 uppercase tracking-tighter">Coord: 44.52 / -102.11</div>
        </div>
      </div>

      <div className="flex-1 relative" ref={canvasRef}>
        {canvasItems.map((item) => (
          <DraggableItem
            key={item.id}
            id={item.id}
            name={item.name}
            type="canvas"
            isMerging={hoveredTargetId === item.id}
            style={{
              left: item.x,
              top: item.y,
            }}
            onDoubleClick={() => cloneItem(item.id)}
          />
        ))}

        {canvasItems.length === 0 && (
          <div className="absolute inset-0 flex items-center justify-center pointer-events-none">
            <motion.div 
              initial={{ opacity: 0, scale: 0.9 }}
              animate={{ opacity: 1, scale: 1 }}
              className="flex flex-col items-center gap-8"
            >
              <div className="relative">
                <div className="absolute inset-0 bg-orange-500 blur-3xl opacity-10 animate-pulse" />
                <div className="relative p-10 rounded-[3rem] bg-zinc-950/40 backdrop-blur-md border border-white/5 flex items-center justify-center">
                  <Hammer className="text-orange-500 animate-[bounce_2s_infinite]" size={64} strokeWidth={1} />
                </div>
              </div>
              <div className="flex flex-col items-center gap-2">
                <p className="text-sm font-black text-zinc-300 uppercase tracking-[0.5em]">
                  The Forge Awaits
                </p>
                <div className="h-px w-32 bg-gradient-to-r from-transparent via-orange-500/30 to-transparent" />
                <p className="text-[10px] font-bold text-zinc-600 uppercase tracking-widest">
                  Deploy Materials to Initiate Synthesis
                </p>
              </div>
            </motion.div>
          </div>
        )}
      </div>

      {/* Tactical Controls */}
      <div className="absolute bottom-10 left-10 flex flex-col gap-4 z-30">
        <motion.button
          whileHover={{ scale: 1.05, backgroundColor: "rgba(220, 38, 38, 0.25)" }}
          whileTap={{ scale: 0.95 }}
          onClick={clearCanvas}
          className="flex items-center gap-4 px-8 py-4 bg-zinc-950/80 backdrop-blur-xl border border-red-500/30 text-red-500/80 hover:text-red-400 hover:border-red-500/60 rounded-[2rem] transition-all shadow-[0_0_30px_rgba(220,38,38,0.15)] group ring-1 ring-white/5"
        >
          <div className="p-2 rounded-full bg-red-500/10 group-hover:bg-red-500/20 transition-colors">
            <Trash2 size={18} className="group-hover:rotate-12 transition-transform" />
          </div>
          <div className="flex flex-col items-start">
            <span className="text-[10px] font-black uppercase tracking-[0.2em] leading-none mb-1">Emergency Reset</span>
            <span className="text-xs font-black uppercase tracking-widest">Extinguish All</span>
          </div>
        </motion.button>
      </div>

      {/* Containment Field Corners */}
      <div className="absolute top-0 left-0 w-32 h-32 border-t-4 border-l-4 border-orange-500/40 pointer-events-none" />
      <div className="absolute top-0 right-0 w-32 h-32 border-t-4 border-r-4 border-orange-500/40 pointer-events-none" />
      <div className="absolute bottom-0 left-0 w-32 h-32 border-b-4 border-l-4 border-orange-500/40 pointer-events-none" />
      <div className="absolute bottom-0 right-0 w-32 h-32 border-b-4 border-r-4 border-orange-500/40 pointer-events-none" />
      </section>
  );
};

export default CraftingCanvas;
