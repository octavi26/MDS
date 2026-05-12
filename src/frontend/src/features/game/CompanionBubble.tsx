import React, { useState } from 'react';
import { MessageSquare, X } from 'lucide-react';

export interface ChatMessage {
  id: string;
  text: string;
  sender: 'ai' | 'user';
  timestamp: Date;
}

interface CompanionBubbleProps {
  messages: ChatMessage[];
}

const CompanionBubble: React.FC<CompanionBubbleProps> = ({ messages }) => {
  const [isOpen, setIsOpen] = useState(false);
  const lastMessage = messages.length > 0 ? messages[messages.length - 1] : null;

  return (
    <div className="fixed bottom-8 right-8 flex flex-col items-end gap-4 z-50">
      {/* Floating Panel (History) */}
      {isOpen && (
        <div className="w-80 h-96 bg-zinc-950/95 backdrop-blur-md border border-zinc-800 rounded-2xl shadow-2xl flex flex-col overflow-hidden animate-in fade-in slide-in-from-bottom-4 duration-300">
          <div className="p-4 border-b border-zinc-800 flex items-center justify-between bg-zinc-900/50">
            <div className="flex items-center gap-2">
              <MessageSquare size={16} className="text-orange-500" />
              <h3 className="text-sm font-bold text-zinc-100 uppercase tracking-wider">Forge Logs</h3>
            </div>
            <button 
              onClick={() => setIsOpen(false)}
              className="p-1 hover:bg-zinc-800 rounded-md transition-colors text-zinc-400"
            >
              <X size={16} />
            </button>
          </div>
          
          <div className="flex-1 overflow-y-auto p-4 space-y-4 scrollbar-thin scrollbar-thumb-zinc-800">
            {messages.length === 0 ? (
              <p className="text-center text-zinc-600 text-sm mt-10 italic">No logs yet...</p>
            ) : (
              messages.map((msg) => (
                <div 
                  key={msg.id} 
                  className={`flex flex-col ${msg.sender === 'ai' ? 'items-start' : 'items-end'}`}
                >
                  <div 
                    className={`max-w-[85%] p-3 rounded-2xl text-sm ${
                      msg.sender === 'ai' 
                        ? 'bg-zinc-800 text-zinc-200 rounded-bl-none' 
                        : 'bg-orange-600 text-white rounded-br-none'
                    }`}
                  >
                    {msg.text}
                  </div>
                  <span className="text-[10px] text-zinc-600 mt-1 px-1">
                    {msg.timestamp.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                  </span>
                </div>
              ))
            )}
          </div>
        </div>
      )}

      {/* Bubble (Last Message Preview) */}
      {!isOpen && lastMessage && (
        <div className="animate-in fade-in slide-in-from-right-4 bg-zinc-100 text-zinc-900 p-4 rounded-2xl rounded-br-none shadow-2xl max-w-[280px] border border-white/20 relative">
          <p className="text-sm font-semibold leading-relaxed tracking-tight">
            {lastMessage.text}
          </p>
          <div
            className="absolute -bottom-2 right-0 w-4 h-4 bg-zinc-100"
            style={{ clipPath: 'polygon(0 0, 100% 0, 100% 100%)' }}
          />
        </div>
      )}

      {/* Avatar Button */}
      <button 
        onClick={() => setIsOpen(!isOpen)}
        className="group relative pointer-events-auto"
      >
        <div className="absolute inset-0 bg-orange-500 rounded-full blur-md opacity-20 group-hover:opacity-40 transition-opacity" />
        <div className="w-16 h-16 bg-gradient-to-br from-zinc-800 to-zinc-950 rounded-full border-2 border-orange-500/50 flex items-center justify-center text-3xl shadow-xl ring-4 ring-zinc-900/50 transition-all duration-300 group-hover:scale-110 group-hover:border-orange-500 group-active:scale-95">
          <span className="drop-shadow-md group-hover:animate-bounce">🤖</span>
        </div>
        {messages.length > 0 && !isOpen && (
          <div className="absolute -top-1 -right-1 w-5 h-5 bg-orange-600 text-white text-[10px] font-bold rounded-full flex items-center justify-center border-2 border-zinc-950">
            {messages.length}
          </div>
        )}
      </button>
    </div>
  );
};

export default CompanionBubble;
