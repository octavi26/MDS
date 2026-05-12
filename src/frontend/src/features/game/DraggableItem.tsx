import React from 'react';
import { useDraggable } from '@dnd-kit/core';
import ItemCard from './ItemCard';

interface DraggableItemProps {
  id: string;
  name: string;
  type: 'inventory' | 'canvas';
  onClick?: () => void;
  onDoubleClick?: () => void;
  style?: React.CSSProperties;
  className?: string;
}

const DraggableItem: React.FC<DraggableItemProps> = ({ 
  id, 
  name, 
  type, 
  onClick, 
  onDoubleClick,
  style,
  className
}) => {
  const { attributes, listeners, setNodeRef, isDragging } = useDraggable({
    id: id,
    data: { name, type, originId: id }
  });

  // Hide the original item while dragging to avoid "ghost" elements 
  // and make the DragOverlay experience seamless.
  const itemStyle: React.CSSProperties = {
    ...style,
    visibility: isDragging ? 'hidden' : undefined,
  };

  return (
    <div
      ref={setNodeRef}
      {...attributes}
      {...listeners}
      onClick={onClick}
      onDoubleClick={onDoubleClick}
      className={`${type === 'canvas' ? 'absolute min-w-[120px]' : ''} ${className || ''}`}
      style={itemStyle}
    >
      <ItemCard 
        name={name} 
        className={type === 'inventory' ? 'bg-zinc-800/40' : ''} 
      />
    </div>
  );
};

export default DraggableItem;
