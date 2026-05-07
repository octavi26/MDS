import React from 'react';
import { useDraggable } from '@dnd-kit/core';
import { CSS } from '@dnd-kit/utilities';

interface DraggableItemProps {
  id: string;
  name: string;
  type: 'inventory' | 'canvas';
  onClick?: () => void;
  onDoubleClick?: () => void;
  style?: React.CSSProperties;
}

const DraggableItem: React.FC<DraggableItemProps> = ({ 
  id, 
  name, 
  type, 
  onClick, 
  onDoubleClick,
  style 
}) => {
  const { attributes, listeners, setNodeRef, transform, isDragging } = useDraggable({
    id: id,
    data: { name, type, originId: id }
  });

  const dndStyle = {
    transform: CSS.Translate.toString(transform),
    zIndex: isDragging ? 50 : undefined,
    opacity: isDragging ? 0.5 : undefined,
    ...style
  };

  return (
    <div
      ref={setNodeRef}
      style={dndStyle}
      {...attributes}
      {...listeners}
      onClick={onClick}
      onDoubleClick={onDoubleClick}
      className={`
        group flex items-center p-3 rounded-xl border transition-all cursor-grab active:cursor-grabbing shadow-sm select-none
        ${type === 'inventory' 
          ? 'bg-zinc-800/40 border-zinc-700/50 hover:bg-zinc-800 hover:border-zinc-500' 
          : 'bg-zinc-800 border-zinc-700 hover:border-blue-500/50 absolute min-w-[100px]'}
      `}
    >
      <div className="w-8 h-8 rounded-lg bg-zinc-700 flex items-center justify-center text-lg mr-3 shadow-inner group-hover:bg-zinc-600 transition-colors pointer-events-none">
        ✨
      </div>
      <span className="text-sm font-medium text-zinc-300 group-hover:text-zinc-100 transition-colors pointer-events-none">
        {name}
      </span>
    </div>
  );
};

export default DraggableItem;
