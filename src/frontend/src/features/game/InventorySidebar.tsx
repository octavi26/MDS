import React, { useState } from 'react';
import { Search, X, ShieldAlert, Binary } from 'lucide-react';
import { motion, AnimatePresence } from 'framer-motion';
import DraggableItem from './DraggableItem';
import { useGameStore } from './gameStore';

interface InventorySidebarProps {
  items: string[];
}

const InventorySidebar: React.FC<InventorySidebarProps> = ({ items }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const addItem = useGameStore((state) => state.addItem);

  const filteredItems = items.filter((item) =>
    item.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleItemClick = (name: string) => {
    const x = 100 + Math.random() * 300;
    const y = 100 + Math.random() * 300;
    addItem(name, x, y);
  };

  return (
    <div className="w-80 border-r border-white/5 bg-zinc-950/40 backdrop-blur-3xl flex flex-col h-full overflow-hidden shrink-0 z-20 relative">
      {/* Decorative Scanline */}
      <div className="absolute inset-0 scanline-container pointer-events-none opacity-20" />
      
      <div className="p-8 border-b border-white/5 bg-white/[0.02] space-y-8 relative z-10">
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-3">
            <div className="p-2.5 rounded-xl bg-orange-500/10 border border-orange-500/20 shadow-[0_0_15px_rgba(234,88,12,0.1)]">
              <Binary size={20} className="text-orange-500" />
            </div>
            <div className="flex flex-col">
              <h2 className="text-[10px] font-black text-zinc-500 uppercase tracking-[0.3em] leading-none mb-1.5">Material Database</h2>
              <span className="text-sm font-black text-zinc-100 uppercase tracking-tight">The Armory</span>
            </div>
          </div>
          <div className="flex items-center gap-1.5 bg-zinc-900/50 px-2 py-1 rounded-lg border border-white/5">
            <div className="h-1.5 w-1.5 rounded-full bg-green-500 animate-pulse" />
            <span className="text-[8px] font-black text-zinc-500 uppercase tracking-widest">Live</span>
          </div>
        </div>
        
        <div className="relative group">
          <Search 
            className={`absolute left-4 top-1/2 -translate-y-1/2 transition-all duration-300 ${
              searchTerm ? 'text-orange-400' : 'text-zinc-600'
            } group-focus-within:text-orange-400 group-focus-within:scale-110`} 
            size={16} 
          />
          <input 
            type="text" 
            placeholder="Search material matrix..." 
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="w-full bg-zinc-950/60 border border-white/5 rounded-2xl py-4 pl-12 pr-12 text-sm text-zinc-100 placeholder:text-zinc-600 focus:outline-none focus:ring-2 focus:ring-orange-500/20 focus:border-orange-500/40 transition-all shadow-inner"
          />
          <AnimatePresence>
            {searchTerm && (
              <motion.button
                initial={{ opacity: 0, scale: 0.8 }}
                animate={{ opacity: 1, scale: 1 }}
                exit={{ opacity: 0, scale: 0.8 }}
                onClick={() => setSearchTerm('')}
                className="absolute right-4 top-1/2 -translate-y-1/2 text-zinc-500 hover:text-orange-400 transition-colors p-1"
              >
                <X size={14} />
              </motion.button>
            )}
          </AnimatePresence>
        </div>
      </div>

      <div className="flex-1 overflow-y-auto p-6 space-y-3 relative z-10 scrollbar-thin scrollbar-thumb-orange-500/20 scrollbar-track-transparent">
        {filteredItems.length > 0 ? (
          filteredItems.map((item, index) => (
            <div key={`${item}-${index}`} className="w-full">
              <DraggableItem
                id={`inv-${item}-${index}`}
                name={item}
                type="inventory"
                className="w-full"
                onClick={() => handleItemClick(item)}
              />
            </div>
          ))
        ) : (
            <motion.div 
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              className="flex flex-col items-center justify-center h-full opacity-40 text-center py-20"
            >
              <ShieldAlert className="text-zinc-600 mb-4" size={32} />
              <p className="text-[10px] font-black uppercase tracking-[0.2em] text-zinc-500 leading-relaxed px-4">
                {searchTerm ? `No matches found in forge matrix for "${searchTerm}"` : 'Database currently void of materials'}
              </p>
            </motion.div>
        )}
      </div>

      <div className="p-6 bg-white/[0.01] border-t border-white/5 relative z-10">
        <div className="flex flex-col gap-4">
          <div className="flex items-center justify-between">
            <div className="flex flex-col">
              <span className="text-[10px] text-zinc-500 uppercase font-black tracking-widest leading-none mb-1">Knowledge Coverage</span>
              <span className="text-xs font-black text-orange-500/90">{items.length} Elements Decoded</span>
            </div>
            <div className="text-right">
              <span className="text-[10px] text-zinc-600 font-bold block">Stability</span>
              <span className="text-[10px] font-black text-green-500/80 uppercase">99.8%</span>
            </div>
          </div>
          <div className="h-1.5 w-full bg-zinc-900/80 rounded-full overflow-hidden border border-white/5 p-[1px]">
            <motion.div 
              initial={{ width: 0 }}
              animate={{ width: `${Math.min(100, (items.length / 50) * 100)}%` }}
              className="h-full bg-gradient-to-r from-orange-600 to-yellow-500 shadow-[0_0_15px_rgba(234,88,12,0.5)] rounded-full"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default InventorySidebar;
