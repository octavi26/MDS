import React from 'react';
import { useDraggable } from '@dnd-kit/core';
import ItemCard from './ItemCard';

interface DraggableItemProps {
  id: string;
  name: string;
  type: 'inventory' | 'canvas';
  isMerging?: boolean;
  onClick?: () => void;
  onDoubleClick?: () => void;
  style?: React.CSSProperties;
  className?: string;
  variant?: 'inventory' | 'canvas';
}

const DraggableItem: React.FC<DraggableItemProps> = ({ 
  id, 
  name, 
  type, 
  isMerging,
  onClick, 
  onDoubleClick,
  style,
  className,
  variant
}) => {
  const { attributes, listeners, setNodeRef, isDragging } = useDraggable({
    id: id,
    data: { name, type, originId: id }
  });

  const itemStyle: React.CSSProperties = {
    ...style,
    visibility: isDragging ? 'hidden' : 'visible',
    opacity: isDragging ? 0 : 1,
    pointerEvents: isDragging ? 'none' : undefined,
  };

  return (
    <div
      ref={setNodeRef}
      {...attributes}
      {...listeners}
      onClick={onClick}
      onDoubleClick={onDoubleClick}
      className={`${type === 'canvas' ? 'absolute' : ''} ${className || ''}`}
      style={itemStyle}
    >
      <ItemCard 
        name={name} 
        isMerging={isMerging}
        isDragging={isDragging}
        variant={variant || type}
        className={type === 'inventory' ? 'bg-zinc-800/40' : ''} 
      />
    </div>
  );
};

export default DraggableItem;
