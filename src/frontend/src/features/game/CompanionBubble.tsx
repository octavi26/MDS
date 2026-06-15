import React, { useState } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { Terminal, X, Cpu, Volume2, VolumeX } from 'lucide-react';

export interface ChatMessage {
  id: string;
  text: string;
  sender: 'ai' | 'user';
  timestamp?: Date;
}

interface CompanionBubbleProps {
  messages: ChatMessage[];
  muted?: boolean;
  onToggleMute?: () => void;
}

const CompanionBubble: React.FC<CompanionBubbleProps> = ({ messages, muted = false, onToggleMute }) => {
  const [isOpen, setIsOpen] = useState(false);
  const lastMessage = messages.length > 0 ? messages[messages.length - 1] : null;

  return (
    <div className="fixed bottom-8 right-8 flex flex-col items-end gap-4 z-50 pointer-events-none">
      <AnimatePresence>
        {/* Advanced HUD Chat Panel */}
        {isOpen && (
          <motion.div 
            initial={{ opacity: 0, y: 20, scale: 0.95 }}
            animate={{ opacity: 1, y: 0, scale: 1 }}
            exit={{ opacity: 0, y: 20, scale: 0.95 }}
            className="w-80 h-[28rem] bg-zinc-950/40 backdrop-blur-2xl border border-white/10 rounded-3xl shadow-[0_0_50px_rgba(0,0,0,0.5)] flex flex-col overflow-hidden pointer-events-auto ring-1 ring-white/5"
          >
            {/* HUD Header */}
            <div className="p-5 border-b border-white/5 flex items-center justify-between bg-white/[0.02]">
              <div className="flex items-center gap-3">
                <div className="p-2 rounded-lg bg-orange-500/10 border border-orange-500/20">
                  <Terminal size={14} className="text-orange-500" />
                </div>
                <div className="flex flex-col">
                  <h3 className="text-[10px] font-black text-zinc-100 uppercase tracking-[0.2em]">Forge Intelligence</h3>
                  <span className="text-[8px] font-bold text-orange-500/60 uppercase tracking-widest">Protocol v4.2.0</span>
                </div>
              </div>
              <button 
                onClick={() => setIsOpen(false)}
                className="p-2 hover:bg-white/5 rounded-xl transition-all text-zinc-500 hover:text-orange-400 border border-transparent hover:border-white/5"
              >
                <X size={16} />
              </button>
            </div>
            
            {/* HUD Log Stream */}
            <div className="flex-1 overflow-y-auto p-5 space-y-6 scrollbar-none">
              {messages.length === 0 ? (
                <div className="flex flex-col items-center justify-center h-full opacity-20">
                  <Cpu size={32} className="mb-4 text-zinc-400" />
                  <p className="text-[10px] font-black text-zinc-500 uppercase tracking-widest">Awaiting Input...</p>
                </div>
              ) : (
                messages.map((msg) => (
                  <motion.div 
                    initial={{ opacity: 0, x: msg.sender === 'ai' ? -10 : 10 }}
                    animate={{ opacity: 1, x: 0 }}
                    key={msg.id} 
                    className={`flex flex-col ${msg.sender === 'ai' ? 'items-start' : 'items-end'}`}
                  >
                    <div 
                      className={`max-w-[90%] p-4 rounded-2xl text-xs font-medium leading-relaxed ${
                        msg.sender === 'ai' 
                          ? 'bg-white/5 text-zinc-300 rounded-bl-none border border-white/5' 
                          : 'bg-orange-600/90 text-white rounded-br-none shadow-[0_0_20px_rgba(234,88,12,0.3)]'
                      }`}
                    >
                      {msg.text}
                    </div>
                    {msg.timestamp && (
                      <span className="text-[9px] font-bold text-zinc-600 mt-2 px-1 uppercase tracking-tighter">
                        [{msg.timestamp.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', second: '2-digit' })}]
                      </span>
                    )}
                  </motion.div>
                ))
              )}
            </div>

            {/* HUD Footer Decor */}
            <div className="p-3 bg-white/[0.01] border-t border-white/5 flex justify-center gap-1">
              {[...Array(8)].map((_, i) => (
                <div key={i} className="h-0.5 w-6 bg-zinc-800 rounded-full" />
              ))}
            </div>
          </motion.div>
        )}
      </AnimatePresence>

      {/* Preview Bubble */}
      <AnimatePresence>
        {!isOpen && lastMessage && (
          <motion.div 
            initial={{ opacity: 0, scale: 0.9, x: 20 }}
            animate={{ opacity: 1, scale: 1, x: 0 }}
            exit={{ opacity: 0, scale: 0.9, x: 20 }}
            className="bg-zinc-100 text-zinc-900 p-4 rounded-2xl rounded-br-none shadow-2xl max-w-[280px] border border-white/20 relative"
          >
            <p className="text-xs font-bold leading-relaxed tracking-tight">
              {lastMessage.text}
            </p>
            <div
              className="absolute -bottom-2 right-0 w-4 h-4 bg-zinc-100"
              style={{ clipPath: 'polygon(0 0, 100% 0, 100% 100%)' }}
            />
          </motion.div>
        )}
      </AnimatePresence>

      {/* Voice Mute Toggle */}
      {onToggleMute && (
        <button
          onClick={onToggleMute}
          title={muted ? 'Unmute boss voice' : 'Mute boss voice'}
          className={`pointer-events-auto p-2.5 rounded-xl border backdrop-blur-md transition-all shadow-lg ${
            muted
              ? 'bg-zinc-900/60 border-white/10 text-zinc-500 hover:text-zinc-300'
              : 'bg-orange-500/10 border-orange-500/30 text-orange-400 hover:text-orange-300'
          }`}
        >
          {muted ? <VolumeX size={16} /> : <Volume2 size={16} />}
        </button>
      )}

      {/* Animated Avatar Core */}
      <button
        onClick={() => setIsOpen(!isOpen)}
        className="group relative pointer-events-auto"
      >
        <div className="absolute inset-0 bg-orange-500 rounded-full opacity-10 group-hover:opacity-20 transition-opacity" />
        <motion.div 
          animate={{ rotate: isOpen ? 180 : 0 }}
          className="w-20 h-20 bg-zinc-950/60 backdrop-blur-md rounded-full border border-white/10 flex items-center justify-center text-4xl shadow-2xl ring-1 ring-white/5 transition-all duration-500 group-hover:scale-110 group-hover:border-orange-500/50"
        >
          <div className="relative">
            <span className="drop-shadow-[0_0_10px_rgba(255,255,255,0.5)] group-hover:animate-pulse">🤖</span>
            {messages.length > 0 && !isOpen && (
              <motion.div 
                initial={{ scale: 0 }}
                animate={{ scale: 1 }}
                className="absolute -top-1 -right-1 w-6 h-6 bg-orange-600 text-white text-[10px] font-black rounded-full flex items-center justify-center border-2 border-zinc-950 shadow-[0_0_15px_rgba(234,88,12,0.6)]"
              >
                {messages.length}
              </motion.div>
            )}
          </div>
        </motion.div>
        
        {/* Orbital Decor */}
        <div className="absolute inset-0 border border-orange-500/15 rounded-full [mask-image:linear-gradient(transparent,black)]" />
      </button>
    </div>
  );
};

export default CompanionBubble;
