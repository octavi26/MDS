import React from 'react';
import { motion } from 'framer-motion';
import { itemData } from '../../data/mockData';

interface ItemCardProps {
  name: string;
  isDragging?: boolean;
  isMerging?: boolean;
  className?: string;
  style?: React.CSSProperties;
  variant?: 'inventory' | 'canvas';
}

const ItemCard: React.FC<ItemCardProps> = ({ name, isDragging, isMerging, className, style, variant = 'canvas' }) => {
  const emoji = itemData[name] || '✨';

  return (
    <motion.div
      whileHover={{ scale: 1.01, y: -1 }}
      whileTap={{ scale: 0.98 }}
      animate={isMerging ? {
        scale: [1, 1.05, 1],
        boxShadow: [
          "0 0 15px rgba(234, 88, 12, 0.3), inset 0 0 8px rgba(234, 88, 12, 0.1)",
          "0 0 40px rgba(251, 191, 36, 0.7), inset 0 0 20px rgba(251, 191, 36, 0.4)",
          "0 0 15px rgba(234, 88, 12, 0.3), inset 0 0 8px rgba(234, 88, 12, 0.1)"
        ],
        borderColor: ["rgba(234, 88, 12, 0.3)", "rgba(251, 191, 36, 0.8)", "rgba(234, 88, 12, 0.3)"]
      } : {}}
      transition={isMerging ? { repeat: Infinity, duration: 0.6, ease: "easeInOut" } : {}}
      style={style}
      className={`
        flex items-center p-2 rounded-2xl border select-none 
        bg-zinc-900/80 backdrop-blur-2xl border-white/10 shadow-[0_8px_32px_0_rgba(0,0,0,0.5)]
        hover:border-orange-500/40 hover:bg-zinc-800 group relative overflow-hidden
        h-[56px] shrink-0
        ${variant === 'canvas' ? 'w-[120px]' : 'w-full'}
        ${variant === 'inventory' ? 'bg-zinc-900/60' : 'bg-zinc-900/80'}
        ${isDragging 
          ? 'opacity-100 cursor-grabbing shadow-[0_0_40px_rgba(255,95,31,0.4)] border-orange-500 ring-1 ring-orange-500/20 z-[100] !w-[120px]' 
          : 'cursor-grab transition-all duration-200'}
        ${isMerging ? 'bg-orange-500/20 border-yellow-400 z-50' : ''}
        ${className}
      `}
    >
      {/* Internal Glow for merging */}
      {isMerging && (
        <motion.div 
          animate={{ opacity: [0.1, 0.2, 0.1] }}
          transition={{ repeat: Infinity, duration: 0.6 }}
          className="absolute inset-0 bg-gradient-to-br from-orange-500 to-yellow-400 pointer-events-none"
        />
      )}

      <div className="w-10 h-10 rounded-xl bg-gradient-to-br from-zinc-800/80 to-zinc-950 border border-white/10 flex items-center justify-center text-xl mr-3 shadow-xl transition-all duration-300 group-hover:rotate-3 group-hover:scale-105 relative z-10 shrink-0">
        <span className="drop-shadow-[0_2px_4px_rgba(0,0,0,0.5)]">{emoji}</span>
      </div>

      <div className="flex flex-col relative z-10 overflow-hidden">
        <span className="text-xs font-black text-zinc-100 tracking-tight leading-none group-hover:text-orange-400 transition-colors duration-200 truncate">
          {name}
        </span>
      </div>

      {/* Decorative corner */}
      <div className="absolute top-0 right-0 w-6 h-6 bg-orange-500/5 rotate-45 translate-x-3 -translate-y-3 border-l border-white/5" />
    </motion.div>
  );
};

export default ItemCard;
