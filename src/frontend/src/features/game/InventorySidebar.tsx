import React, { useState } from 'react';
import { Search, X } from 'lucide-react';

interface InventorySidebarProps {
  items: string[];
}

const InventorySidebar: React.FC<InventorySidebarProps> = ({ items }) => {
  const [searchTerm, setSearchTerm] = useState('');

  // Filter items based on search term (case-insensitive partial match)
  const filteredItems = items.filter((item) =>
    item.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="w-64 border-r border-zinc-800 bg-zinc-900/30 flex flex-col h-full overflow-hidden">
      {/* Sidebar Header */}
      <div className="p-4 border-b border-zinc-800 bg-zinc-900/50">
        <h2 className="text-sm font-semibold text-zinc-400 uppercase tracking-tight mb-4">Inventory</h2>
        
        {/* Functional Search Bar */}
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

      {/* Item List */}
      <div className="flex-1 overflow-y-auto p-4 custom-scrollbar">
        <div className="grid grid-cols-1 gap-2">
          {filteredItems.length > 0 ? (
            filteredItems.map((item, index) => (
              <div 
                key={`${item}-${index}`}
                className="group flex items-center p-3 bg-zinc-800/40 border border-zinc-700/50 rounded-xl hover:bg-zinc-800 hover:border-zinc-500 transition-all cursor-pointer shadow-sm active:scale-95"
              >
                <div className="w-8 h-8 rounded-lg bg-zinc-700 flex items-center justify-center text-lg mr-3 shadow-inner group-hover:bg-zinc-600 transition-colors">
                  ✨
                </div>
                <span className="text-sm font-medium text-zinc-300 group-hover:text-zinc-100 transition-colors">
                  {item}
                </span>
              </div>
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

      {/* Footer Info */}
      <div className="p-3 bg-zinc-900/50 border-t border-zinc-800 text-[10px] text-zinc-600 flex justify-between uppercase tracking-widest font-bold">
        <span>Items Found</span>
        <span>{items.length}</span>
      </div>
    </div>
  );
};

export default InventorySidebar;
