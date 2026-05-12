import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
import { motion } from 'framer-motion';
import { Flame, Target, Box, Zap, ChevronRight } from 'lucide-react';
import { apiClient } from '../../api/apiClient';
import type { Level } from '../../api/apiClient';

const LevelSelectionScreen: React.FC = () => {
  const navigate = useNavigate();
  const { data: levels, isLoading, error } = useQuery({
    queryKey: ['levels'],
    queryFn: apiClient.getLevels,
  });

  if (isLoading) {
    return (
      <div className="min-h-screen bg-[#0c0a09] text-zinc-100 flex items-center justify-center scanline-container overflow-hidden">
        <div className="absolute inset-0 bg-[radial-gradient(circle_at_center,rgba(120,53,15,0.15)_0%,transparent_70%)] animate-ember-pulse" />
        <div className="flex flex-col items-center gap-4 relative z-10">
          <motion.div 
            animate={{ rotate: 360 }}
            transition={{ duration: 2, repeat: Infinity, ease: "linear" }}
            className="p-4 rounded-full bg-orange-500/10 border border-orange-500/20 shadow-[0_0_20px_rgba(234,88,12,0.2)]"
          >
            <Flame className="text-orange-500" size={32} />
          </motion.div>
          <span className="magma-text text-lg uppercase tracking-[0.3em] font-black">Syncing Blueprints...</span>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="min-h-screen bg-[#0c0a09] text-red-400 flex items-center justify-center p-8 text-center">
        <div className="max-w-md space-y-6">
          <div className="inline-flex p-4 rounded-full bg-red-500/10 border border-red-500/20">
            <Zap className="text-red-500" size={32} />
          </div>
          <h1 className="text-2xl font-black uppercase tracking-widest text-red-500">Critical Failure</h1>
          <p className="text-zinc-500 font-medium leading-relaxed">
            The forgery network is unreachable. Please ensure the backend matrix is active and try again.
          </p>
          <button 
            onClick={() => window.location.reload()}
            className="px-8 py-3 bg-red-500/10 border border-red-500/20 text-red-500 font-black uppercase tracking-widest rounded-2xl hover:bg-red-500/20 transition-all"
          >
            Re-establish Link
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-[#0c0a09] text-zinc-100 p-8 md:p-16 scanline-container overflow-x-hidden">
      {/* Background Decor */}
      <div className="absolute inset-0 bg-[radial-gradient(circle_at_center,rgba(120,53,15,0.1)_0%,transparent_80%)] animate-ember-pulse pointer-events-none" />
      <div className="absolute inset-0 forgery-grid pointer-events-none" />
      
      <div className="max-w-7xl mx-auto relative z-10">
        <header className="mb-20 text-center space-y-4">
          <motion.div
            initial={{ y: -20, opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
          >
            <h1 className="text-6xl md:text-8xl font-black tracking-tighter magma-text uppercase mb-4">
              Mocking Forge
            </h1>
            <div className="flex items-center justify-center gap-4">
              <div className="h-px w-12 bg-gradient-to-r from-transparent to-orange-500/50" />
              <p className="text-[10px] md:text-xs text-zinc-500 uppercase tracking-[0.5em] font-black">
                Neural Synthesis & Material Forgery
              </p>
              <div className="h-px w-12 bg-gradient-to-l from-transparent to-orange-500/50" />
            </div>
          </motion.div>
        </header>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {levels?.map((level: Level, index: number) => (
            <motion.div
              key={level.id}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: index * 0.1 }}
              onClick={() => navigate(`/game/${level.id}`)}
              className="group relative cursor-pointer"
            >
              {/* Card Container */}
              <div className="glass-panel p-8 rounded-[2rem] border border-white/5 group-hover:border-orange-500/30 transition-all duration-500 group-hover:shadow-[0_0_50px_rgba(234,88,12,0.15)] group-active:scale-[0.98]">
                {/* Header */}
                <div className="flex items-start justify-between mb-8">
                  <div className="p-3 rounded-2xl bg-orange-500/5 border border-orange-500/10 group-hover:bg-orange-500/10 group-hover:border-orange-500/30 transition-all duration-500">
                    <Box className="text-zinc-600 group-hover:text-orange-500 transition-colors" size={24} />
                  </div>
                  <div className="text-right">
                    <span className="text-[10px] font-black text-zinc-600 uppercase tracking-widest block mb-1">Index</span>
                    <span className="text-sm font-bold text-zinc-400">#00{level.id}</span>
                  </div>
                </div>

                {/* Content */}
                <div className="space-y-6 mb-10">
                  <div>
                    <h2 className="text-2xl font-black text-zinc-100 group-hover:text-orange-400 transition-colors uppercase tracking-tight">
                      {level.name.split(':')[1] || level.name}
                    </h2>
                    <p className="text-[10px] text-zinc-500 uppercase tracking-widest font-bold mt-1">
                      {level.name.split(':')[0] || 'Mission'}
                    </p>
                  </div>

                  <div className="bg-zinc-950/50 p-4 rounded-2xl border border-white/5 space-y-3">
                    <div className="flex items-center gap-3">
                      <Target className="text-orange-600" size={14} />
                      <span className="text-[10px] font-black text-zinc-500 uppercase tracking-widest">Synthesis Goal</span>
                    </div>
                    <div className="flex items-center gap-2">
                      <span className="text-lg font-black text-orange-400 uppercase tracking-tighter">{level.goalItem}</span>
                      <div className="h-1.5 w-1.5 rounded-full bg-orange-500/50 animate-pulse" />
                    </div>
                  </div>
                </div>

                {/* Footer */}
                <div className="flex items-center justify-between pt-6 border-t border-white/5">
                  <div className="flex -space-x-2">
                    {level.startingItems.slice(0, 4).map((item, i) => (
                      <div 
                        key={item}
                        title={item}
                        className="w-8 h-8 rounded-full bg-zinc-900 border-2 border-stone-900 flex items-center justify-center text-xs shadow-xl relative"
                        style={{ zIndex: 10 - i }}
                      >
                        <span className="scale-75 opacity-60">✨</span>
                      </div>
                    ))}
                  </div>
                  <div className="flex items-center gap-2 text-orange-500/50 group-hover:text-orange-500 transition-all font-black uppercase text-[10px] tracking-widest">
                    Initialize
                    <ChevronRight size={14} className="group-hover:translate-x-1 transition-transform" />
                  </div>
                </div>
              </div>
              
              {/* Hover Glow Effect */}
              <div className="absolute inset-0 bg-orange-500/5 blur-3xl rounded-[2rem] opacity-0 group-hover:opacity-100 transition-opacity pointer-events-none" />
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default LevelSelectionScreen;
