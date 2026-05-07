import React from 'react';

interface ItemCardProps {
  name: string;
  isDragging?: boolean;
  className?: string;
  style?: React.CSSProperties;
}

const ItemCard: React.FC<ItemCardProps> = ({ name, isDragging, className, style }) => {
  return (
    <div
      style={style}
      className={`
        flex items-center p-3 rounded-xl border select-none transition-shadow
        bg-zinc-800 border-zinc-700 shadow-sm
        ${isDragging ? 'opacity-50 cursor-grabbing shadow-2xl scale-105 border-blue-500/50 ring-2 ring-blue-500/20' : 'cursor-grab hover:border-zinc-500 active:cursor-grabbing'}
        ${className}
      `}
    >
      <div className="w-8 h-8 rounded-lg bg-zinc-700 flex items-center justify-center text-lg mr-3 shadow-inner pointer-events-none">
        ✨
      </div>
      <span className="text-sm font-medium text-zinc-300 pointer-events-none">
        {name}
      </span>
    </div>
  );
};

export default ItemCard;
