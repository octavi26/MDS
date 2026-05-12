import React from 'react';
import { itemData } from '../../data/mockData';

interface ItemCardProps {
  name: string;
  isDragging?: boolean;
  className?: string;
  style?: React.CSSProperties;
}

const ItemCard: React.FC<ItemCardProps> = ({ name, isDragging, className, style }) => {
  const emoji = itemData[name] || '✨';

  return (
    <div
      style={style}
      className={`
        flex items-center p-3 rounded-xl border select-none transition-all duration-200
        bg-zinc-900/80 backdrop-blur-sm border-zinc-800 shadow-lg group
        ${isDragging 
          ? 'opacity-50 cursor-grabbing shadow-2xl scale-105 border-orange-500/50 ring-2 ring-orange-500/20' 
          : 'cursor-grab hover:border-orange-500/50 hover:bg-zinc-800 active:cursor-grabbing active:scale-95'}
        ${className}
      `}
    >
      <div className="w-10 h-10 rounded-lg bg-zinc-800/50 border border-zinc-700/50 flex items-center justify-center text-2xl mr-3 shadow-inner pointer-events-none transition-transform group-hover:scale-110">
        {emoji}
      </div>
      <span className="text-sm font-semibold text-zinc-100 pointer-events-none tracking-tight">
        {name}
      </span>
    </div>
  );
};

export default ItemCard;
