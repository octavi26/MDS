import React, { useState } from 'react';
import { Search, X } from 'lucide-react';
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
    // Spawn at random location within a reasonable range
    const x = 100 + Math.random() * 300;
    const y = 100 + Math.random() * 300;
    addItem(name, x, y);
  };

  return (
    <div className="w-64 border-r border-zinc-800 bg-zinc-900/30 flex flex-col h-full overflow-hidden shrink-0">
      <div className="p-4 border-b border-zinc-800 bg-zinc-900/50">
        <h2 className="text-sm font-semibold text-zinc-400 uppercase tracking-tight mb-4">Inventory</h2>
        <div className="relative group">
          <Search 
            className={`absolute left-3 top-1/2 -translate-y-1/2 transition-colors ${
              searchTerm ? 'text-blue-400' : 'text-zinc-500'
            } group-focus-within:text-blue-400`} 
            size={16} 
          />
          <input 
            type="text" 
            placeholder="Search items..." 
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="w-full bg-zinc-800 border border-zinc-700 rounded-md py-2 pl-10 pr-10 text-sm text-zinc-200 placeholder:text-zinc-600 focus:outline-none focus:ring-1 focus:ring-blue-500/50 focus:border-blue-500/50 transition-all"
          />
          {searchTerm && (
            <button
              onClick={() => setSearchTerm('')}
              className="absolute right-3 top-1/2 -translate-y-1/2 text-zinc-500 hover:text-zinc-300 transition-colors"
            >
              <X size={14} />
            </button>
          )}
        </div>
      </div>

      <div className="flex-1 overflow-y-auto p-4 custom-scrollbar">
        <div className="grid grid-cols-1 gap-2">
          {filteredItems.length > 0 ? (
            filteredItems.map((item, index) => (
              <DraggableItem 
                key={`${item}-${index}`}
                id={`inv-${item}-${index}`}
                name={item}
                type="inventory"
                onClick={() => handleItemClick(item)}
              />
            ))
          ) : (
            <div className="flex flex-col items-center justify-center h-full opacity-30 text-center py-12">
              <p className="text-sm italic">
                {searchTerm ? `No results for "${searchTerm}"` : 'No items discovered yet'}
              </p>
            </div>
          )}
        </div>
      </div>

      <div className="p-3 bg-zinc-900/50 border-t border-zinc-800 text-[10px] text-zinc-600 flex justify-between uppercase tracking-widest font-bold">
        <span>Items Found</span>
        <span>{items.length}</span>
      </div>
    </div>
  );
};

export default InventorySidebar;
