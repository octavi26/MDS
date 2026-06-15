import React, { useState } from 'react';
import { motion } from 'framer-motion';
import { Flame, Zap, User, ArrowRight, Loader2 } from 'lucide-react';
import { apiClient } from '../../api/apiClient';
import { describeError, emitStartupDebug } from '../../debug/startupDebug';

interface RegistrationScreenProps {
  onRegistered: () => void;
}

const RegistrationScreen: React.FC<RegistrationScreenProps> = ({ onRegistered }) => {
  const [username, setUsername] = useState('');
  const [isPending, setIsPending] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!username.trim()) return;

    setIsPending(true);
    setError(null);
    emitStartupDebug('registration', 'pending', `Registering operator "${username.trim()}"`);

    try {
      await apiClient.registerUser(username.trim());
      emitStartupDebug('registration', 'success', 'Operator registration completed');
      onRegistered();
    } catch (err) {
      const message = describeError(err);
      setError(`Neural link failed: ${message}`);
      emitStartupDebug('registration', 'error', message);
      console.error(err);
    } finally {
      setIsPending(false);
    }
  };

  return (
    <div className="relative min-h-screen bg-[#0c0a09] text-zinc-100 flex items-center justify-center p-6 scanline-container overflow-hidden">
      <div className="absolute inset-0 bg-[radial-gradient(circle_at_center,rgba(120,53,15,0.15)_0%,transparent_70%)] animate-ember-pulse" />
      <div className="absolute inset-0 forgery-grid pointer-events-none opacity-20" />
      
      <div className="max-w-md w-full relative z-10">
        <div className="text-center mb-10">
          <div className="inline-flex p-5 rounded-[2.5rem] bg-orange-500/10 border border-orange-500/20 mb-8 shadow-[0_0_24px_rgba(234,88,12,0.22)]">
            <Flame className="text-orange-500" size={40} />
          </div>
          <h1 className="text-5xl font-black tracking-tighter magma-text uppercase mb-3">Identity Required</h1>
          <p className="text-[10px] text-zinc-500 uppercase tracking-[0.4em] font-black">Operator Authorization Protocol</p>
        </div>

        <div className="glass-panel p-10 rounded-[3rem] border border-white/5 relative group overflow-hidden shadow-2xl">
          <div className="absolute inset-0 bg-gradient-to-br from-orange-500/5 to-transparent opacity-0 group-hover:opacity-100 transition-opacity duration-700" />
          
          <form onSubmit={handleSubmit} className="space-y-8 relative z-10">
            <div className="space-y-3">
              <label className="text-[10px] font-black text-zinc-500 uppercase tracking-[0.2em] ml-2">Operator Handle</label>
              <div className="relative">
                <div className="absolute left-6 top-1/2 -translate-y-1/2 text-zinc-600 group-focus-within:text-orange-500 transition-colors">
                  <User size={20} />
                </div>
                <input
                  type="text"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  placeholder="Enter your handle..."
                  className="w-full bg-zinc-950/50 border border-white/5 rounded-3xl py-5 pl-16 pr-6 text-lg font-bold focus:outline-none focus:border-orange-500/50 focus:bg-zinc-950 transition-all placeholder:text-zinc-700"
                  autoFocus
                  required
                />
              </div>
            </div>

            {error && (
              <motion.div 
                initial={{ opacity: 0, x: -10 }}
                animate={{ opacity: 1, x: 0 }}
                className="flex items-center gap-3 p-4 rounded-2xl bg-red-500/10 border border-red-500/20"
              >
                <Zap className="text-red-500 shrink-0" size={16} />
                <span className="text-[10px] font-black text-red-500 uppercase tracking-widest">{error}</span>
              </motion.div>
            )}

            <button
              type="submit"
              disabled={isPending || !username.trim()}
              className="w-full group relative py-6 bg-orange-500 text-zinc-950 font-black uppercase tracking-[0.2em] rounded-[2rem] overflow-hidden hover:bg-orange-400 disabled:opacity-50 disabled:cursor-not-allowed transition-all shadow-[0_20px_40px_rgba(234,88,12,0.2)] active:scale-[0.98]"
            >
              <div className="flex items-center justify-center gap-3">
                {isPending ? (
                  <>
                    <Loader2 className="animate-spin" size={24} />
                    <span>Syncing...</span>
                  </>
                ) : (
                  <>
                    <span>Initialize Forge</span>
                    <ArrowRight className="group-hover:translate-x-1 transition-transform" size={20} />
                  </>
                )}
              </div>
            </button>
          </form>
        </div>

        <div className="mt-12 text-center">
          <p className="text-[9px] text-zinc-600 font-bold uppercase tracking-[0.5em]">System Status: Ready for Synthesis</p>
        </div>
      </div>
    </div>
  );
};

export default RegistrationScreen;
