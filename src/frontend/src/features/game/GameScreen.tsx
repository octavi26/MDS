import React, { useState, useEffect } from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import {
  DndContext,
  useSensor,
  useSensors,
  PointerSensor,
  DragOverlay,
  defaultDropAnimationSideEffects
} from '@dnd-kit/core';
import { motion, AnimatePresence } from 'framer-motion';
import type { DragEndEvent, DragStartEvent, DragMoveEvent, DropAnimation } from '@dnd-kit/core';
import { ChevronLeft, Loader2, Zap } from 'lucide-react';
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { apiClient } from '../../api/apiClient';
import InventorySidebar from './InventorySidebar';
import CraftingCanvas from './CraftingCanvas';
import ItemCard from './ItemCard';
import SparkParticles from './SparkParticles';
import CompanionBubble, { type ChatMessage } from './CompanionBubble';
import { useGameStore } from './gameStore';
import { useCompanion } from './useCompanion';
import { findOverlappingCanvasItem, CANVAS_ITEM_WIDTH, CANVAS_ITEM_HEIGHT } from './craftingCollision';

const dropAnimation: DropAnimation = {
  sideEffects: defaultDropAnimationSideEffects({
    styles: {
      active: {
        opacity: '0.5',
      },
    },
  }),
};

interface DiscoveryEffect {
  id: string;
  x: number;
  y: number;
}

const GameScreen: React.FC = () => {
  const userId = apiClient.getUserId() || '';
  const username = apiClient.getUsername() || 'OPERATOR';
  const { levelId } = useParams<{ levelId: string }>();
  const navigate = useNavigate();
  const queryClient = useQueryClient();
  const { addItem, updateItemPosition, combineItems, canvasItems, clearCanvas } = useGameStore();
  const [activeItem, setActiveItem] = useState<{ id: string, name: string, type: string } | null>(null);
  const [hoveredTargetId, setHoveredTargetId] = useState<string | null>(null);
  const [sessionId, setSessionId] = useState<string | null>(null);
  const [apiCompanionMessage, setApiCompanionMessage] = useState<string | null>(null);
  const [craftingError, setCraftingError] = useState<string | null>(null);
  const [chatMessages, setChatMessages] = useState<ChatMessage[]>([]);
  const [discoveries, setDiscoveries] = useState<DiscoveryEffect[]>([]);
  const [isLevelComplete, setIsLevelComplete] = useState(false);
  const [voiceMuted, setVoiceMuted] = useState(false);

  const canvasRef = React.useRef<HTMLDivElement>(null);

  useEffect(() => {
    // Clear canvas and reset completion when entering a new level
    clearCanvas();
    setIsLevelComplete(false);
    setSessionId(null); // Reset session to force new one for new level
  }, [levelId, clearCanvas]);

  const { data: levels, isLoading: levelsLoading } = useQuery({
    queryKey: ['levels'],
    queryFn: apiClient.getLevels,
  });

  const level = levels?.find((l) => l.id === levelId);

  const startSessionMutation = useMutation({
    mutationFn: ({ userId, lId }: { userId: string, lId: string }) => 
      apiClient.startSession(userId, lId),
    onSuccess: async (data) => {
      setSessionId(data.sessionId);
      try {
        const commentData = await apiClient.getCompanionComment('GameStarted', []);
        setApiCompanionMessage(commentData.comment);
      } catch (err) {
        console.error("Failed to fetch companion comment", err);
      }
    },
  });

  useEffect(() => {
    if (levelId && !sessionId && !startSessionMutation.isPending) {
      startSessionMutation.mutate({ userId, lId: levelId });
    }
  }, [levelId, sessionId, startSessionMutation, userId]);

  const { data: sessionData, isLoading: sessionLoading } = useQuery({
    queryKey: ['session', sessionId],
    queryFn: () => apiClient.getSession(sessionId!),
    enabled: !!sessionId,
  });

  const inventoryItems = sessionData?.inventory.map(i => i.name) || level?.startingItems || [];

  const localCompanion = useCompanion({
    levelName: level?.name,
    goalName: level?.goalItem,
    inventory: level?.startingItems ?? [],
    muted: voiceMuted,
  });

  const craftMutation = useMutation({
    mutationFn: ({
      sourceId,
      targetId,
      elementA,
      elementB,
      x,
      y,
    }: {
      sourceId: string;
      targetId: string;
      elementA: string;
      elementB: string;
      x: number;
      y: number;
    }) => {
      if (!sessionId) {
        throw new Error('Cannot craft without an active session');
      }

      return apiClient.craft(sessionId, elementA, elementB).then((result) => ({
        result,
        sourceId,
        targetId,
        x,
        y,
      }));
    },
    onSuccess: ({ result, sourceId, targetId, x, y }) => {
      // Check if this is a new discovery
      const isNew = !inventoryItems.includes(result.name);
      
      if (isNew) {
        if (canvasRef.current) {
          const rect = canvasRef.current.getBoundingClientRect();
          setDiscoveries(prev => [
            ...prev, 
            { 
              id: Date.now().toString(), 
              x: x + rect.left + CANVAS_ITEM_WIDTH / 2, 
              y: y + rect.top + CANVAS_ITEM_HEIGHT / 2 
            }
          ]);
        }
      }

      if (result.isGoalReached) {
        setIsLevelComplete(true);
        if (canvasRef.current) {
          const rect = canvasRef.current.getBoundingClientRect();
          const goalDiscoveryX = x + rect.left + CANVAS_ITEM_WIDTH / 2;
          const goalDiscoveryY = y + rect.top + CANVAS_ITEM_HEIGHT / 2;
          
          // Large celebration burst
          const bursts = Array.from({ length: 8 }).map((_, i) => ({
            id: `goal-${Date.now()}-${i}`,
            x: goalDiscoveryX + (Math.random() - 0.5) * 200,
            y: goalDiscoveryY + (Math.random() - 0.5) * 200
          }));
          setDiscoveries(prev => [...prev, ...bursts]);
        }
      }

      combineItems(sourceId, targetId, result.name, x, y);
      // A result the player already owns means this attempt got them nowhere —
      // track it so the companion can escalate to hints if it keeps happening.
      if (isNew) {
        localCompanion.notifyElementAdded(result.name);
      } else {
        localCompanion.notifyUnproductiveMove();
      }
      setApiCompanionMessage(null);
      setCraftingError(null);
      void queryClient.invalidateQueries({ queryKey: ['session', sessionId] });
      void queryClient.invalidateQueries({ queryKey: ['levels'] });
    },
    onError: () => {
      setCraftingError('Combination failed. Try again.');
      setApiCompanionMessage(null);
    },
  });

  const handleNextLevel = () => {
    if (!levels || !level) return;
    const currentIndex = levels.findIndex(l => l.id === level.id);
    const nextLevel = levels[currentIndex + 1];
    if (nextLevel) {
      navigate(`/game/${nextLevel.id}`);
    } else {
      navigate('/');
    }
  };

  const currentCompanionMessage = apiCompanionMessage || localCompanion.message;

  useEffect(() => {
    if (currentCompanionMessage) {
      setChatMessages(prev => {
        if (prev.length > 0 && prev[prev.length - 1].text === currentCompanionMessage) {
          return prev;
        }
        return [
          ...prev,
          {
            id: Date.now().toString(),
            text: currentCompanionMessage,
            sender: 'ai',
            timestamp: new Date()
          }
        ];
      });
    }
  }, [currentCompanionMessage]);

  const sensors = useSensors(
    useSensor(PointerSensor, {
      activationConstraint: {
        distance: 5,
      },
    })
  );

  const [dragOffset, setDragOffset] = useState<{ x: number, y: number }>({ x: 0, y: 0 });

  const handleDragStart = (event: DragStartEvent) => {
    const { active, activatorEvent } = event;
    const data = active.data.current;
    if (data) {
      setActiveItem({ id: active.id as string, name: data.name, type: data.type });
      
      // Calculate where on the item the user clicked
      const activator = activatorEvent as MouseEvent;
      const rect = active.rect.current.initial;
      if (rect) {
        setDragOffset({
          x: activator.clientX - rect.left,
          y: activator.clientY - rect.top,
        });
      }
    }
  };

  const handleDragMove = (event: DragMoveEvent) => {
    const { delta, active, activatorEvent } = event;
    const data = active.data.current;
    if (!data || !canvasRef.current) return;

    const rect = canvasRef.current.getBoundingClientRect();
    const activator = activatorEvent as MouseEvent;
    const pointerX = activator.clientX + delta.x;
    const pointerY = activator.clientY + delta.y;

    let currentX = 0;
    let currentY = 0;

    if (data.type === 'inventory') {
      currentX = pointerX - rect.left - CANVAS_ITEM_WIDTH / 2;
      currentY = pointerY - rect.top - CANVAS_ITEM_HEIGHT / 2;
    } else {
      currentX = pointerX - rect.left - dragOffset.x;
      currentY = pointerY - rect.top - dragOffset.y;
    }

    const targetItem = findOverlappingCanvasItem(
      { id: active.id as string, x: currentX, y: currentY, name: data.name },
      currentX,
      currentY,
      canvasItems
    );

    setHoveredTargetId(targetItem?.id || null);
  };

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over, delta, activatorEvent } = event;
    setActiveItem(null);
    setHoveredTargetId(null);

    if (!over || over.id !== 'crafting-canvas' || !canvasRef.current) return;

    const data = active.data.current;
    if (!data) return;

    const rect = canvasRef.current.getBoundingClientRect();
    const activator = activatorEvent as MouseEvent;
    const pointerX = activator.clientX + delta.x;
    const pointerY = activator.clientY + delta.y;

    let x = 0;
    let y = 0;

    if (data.type === 'inventory') {
      x = pointerX - rect.left - CANVAS_ITEM_WIDTH / 2;
      y = pointerY - rect.top - CANVAS_ITEM_HEIGHT / 2;
    } else {
      x = pointerX - rect.left - dragOffset.x;
      y = pointerY - rect.top - dragOffset.y;
    }


    if (data.type === 'inventory') {
      const targetItem = findOverlappingCanvasItem(
        { id: active.id as string, x, y, name: data.name },
        x,
        y,
        canvasItems
      );

      if (targetItem && sessionId && !craftMutation.isPending) {
        craftMutation.mutate({
          sourceId: 'inventory',
          targetId: targetItem.id,
          elementA: data.name,
          elementB: targetItem.name,
          x: (x + targetItem.x) / 2,
          y: (y + targetItem.y) / 2,
        });
      } else {
        addItem(data.name, x, y);
        localCompanion.notifyElementAdded(data.name);
        setApiCompanionMessage(null);
      }
    } else if (data.type === 'canvas') {
      const item = canvasItems.find((i) => i.id === data.originId);
      if (item) {
        const targetItem = findOverlappingCanvasItem(item, x, y, canvasItems);

        if (targetItem && sessionId && !craftMutation.isPending) {
          craftMutation.mutate({
            sourceId: item.id,
            targetId: targetItem.id,
            elementA: item.name,
            elementB: targetItem.name,
            x: (x + targetItem.x) / 2,
            y: (y + targetItem.y) / 2,
          });
          return;
        }

        updateItemPosition(item.id, x, y);
      }
    }
  };

  if (levelsLoading || (sessionId && sessionLoading)) {
    return (
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex items-center justify-center">
        <Loader2 className="animate-spin mr-2 text-orange-500" />
        <span className="magma-text font-black uppercase tracking-widest">Igniting Forge...</span>
      </div>
    );
  }

  if (!level) {
    return (
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex flex-col items-center justify-center p-8">
        <div className="text-center">
          <h1 className="text-3xl font-bold mb-4 magma-text">Forge Connection Lost</h1>
          <p className="text-zinc-400 mb-8 font-medium">The requested blueprints could not be retrieved.</p>
          <button
            onClick={() => navigate('/')}
            className="px-8 py-3 bg-white/5 border border-white/10 text-zinc-100 font-bold rounded-2xl hover:bg-orange-600 transition-all shadow-xl"
          >
            Return to Armory
          </button>
        </div>
      </div>
    );
  }

  return (
    <DndContext 
      sensors={sensors} 
      onDragStart={handleDragStart}
      onDragMove={handleDragMove}
      onDragEnd={handleDragEnd}
    >
      <div className="h-screen flex flex-col bg-zinc-950 text-zinc-100 overflow-hidden">
        <header className="h-20 border-b border-white/5 bg-zinc-950/40 backdrop-blur-md flex items-center justify-between px-8 shrink-0 z-30">
          <div className="flex items-center gap-6">
            <Link 
              to="/" 
              className="p-3 bg-white/5 hover:bg-white/10 border border-white/5 rounded-2xl transition-all text-zinc-400 hover:text-orange-500 group"
              title="Return to Selection"
            >
              <ChevronLeft size={20} className="group-hover:-translate-x-0.5 transition-transform" />
            </Link>
            <div className="flex flex-col">
              <h1 className="text-2xl font-black leading-tight tracking-tighter magma-text uppercase">Mocking Forge</h1>
              <div className="flex items-center gap-2">
                <div className="h-1.5 w-1.5 rounded-full bg-orange-500 animate-pulse" />
                <p className="text-[10px] text-zinc-500 uppercase tracking-[0.3em] font-black">{level.name}</p>
              </div>
            </div>
          </div>

          <motion.div 
            initial={{ y: -20, opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
            className="bg-zinc-900/40 px-6 py-2.5 rounded-2xl border border-white/5 backdrop-blur-md flex items-center gap-4 shadow-2xl"
          >
            <span className="text-[10px] text-zinc-500 font-black uppercase tracking-widest">Target Objective</span>
            <div className="flex items-center gap-2 bg-orange-500/10 px-3 py-1 rounded-lg border border-orange-500/20">
              <span className="text-xs font-black text-orange-500 uppercase tracking-tighter">{level.goalItem}</span>
            </div>
          </motion.div>

          <div className="flex items-center gap-4">
            <div className="flex flex-col items-end">
              <span className="text-[10px] font-black text-zinc-500 uppercase tracking-widest leading-none">Operator</span>
              <span className="text-xs font-bold text-zinc-300">{username.toUpperCase()}</span>
            </div>
            <div className="w-12 h-12 rounded-2xl bg-gradient-to-br from-zinc-800 to-zinc-950 border border-white/5 flex items-center justify-center shadow-2xl overflow-hidden relative group">
              <div className="absolute inset-0 bg-orange-500/10 opacity-0 group-hover:opacity-100 transition-opacity" />
              <span className="text-xs font-black text-orange-500 relative z-10 tracking-tighter">OP-1</span>
            </div>
          </div>
        </header>

        <main className="flex-1 flex overflow-hidden relative bg-[#09090b]">
          <InventorySidebar items={inventoryItems} />
          <CraftingCanvas hoveredTargetId={hoveredTargetId} canvasRef={canvasRef} />
          
          <AnimatePresence>
            {(craftMutation.isPending || craftingError) && (
              <motion.div 
                initial={{ opacity: 0, y: 20, x: '-50%' }}
                animate={{ opacity: 1, y: 0, x: '-50%' }}
                exit={{ opacity: 0, y: 20, x: '-50%' }}
                className="absolute top-24 left-1/2 z-40 rounded-2xl border border-orange-500/20 bg-zinc-950/80 backdrop-blur-xl px-6 py-3 shadow-[0_0_50px_rgba(234,88,12,0.2)]"
              >
                {craftMutation.isPending ? (
                  <div className="flex items-center gap-3">
                    <Loader2 className="animate-spin text-orange-500" size={18} />
                    <span className="text-xs font-black text-orange-500 uppercase tracking-[0.2em]">Synthesizing Element...</span>
                  </div>
                ) : (
                  <div className="flex items-center gap-3">
                    <div className="w-2 h-2 rounded-full bg-red-500 animate-pulse" />
                    <span className="text-xs font-black text-red-400 uppercase tracking-[0.2em]">{craftingError}</span>
                  </div>
                )}
              </motion.div>
            )}
          </AnimatePresence>
          
          <CompanionBubble
            messages={chatMessages}
            muted={voiceMuted}
            onToggleMute={() => setVoiceMuted((m) => !m)}
          />
          
          {discoveries.map(discovery => (
            <SparkParticles
              key={discovery.id}
              x={discovery.x}
              y={discovery.y}
              onComplete={() => setDiscoveries(prev => prev.filter(d => d.id !== discovery.id))}
            />
          ))}

          <AnimatePresence>
            {isLevelComplete && (
              <motion.div 
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
                className="absolute inset-0 z-50 flex items-center justify-center bg-zinc-950/60 backdrop-blur-md p-6"
              >
                <motion.div 
                  initial={{ scale: 0.9, y: 20 }}
                  animate={{ scale: 1, y: 0 }}
                  className="max-w-md w-full glass-panel p-10 rounded-[2.5rem] border border-orange-500/30 shadow-[0_0_100px_rgba(234,88,12,0.2)] text-center relative overflow-hidden"
                >
                  <div className="absolute top-0 left-0 w-full h-1 bg-gradient-to-r from-transparent via-orange-500 to-transparent" />
                  
                  <div className="mb-8 flex justify-center">
                    <div className="p-5 rounded-full bg-orange-500/10 border border-orange-500/20 shadow-[0_0_30px_rgba(234,88,12,0.2)]">
                      <Zap className="text-orange-500 animate-pulse" size={40} />
                    </div>
                  </div>

                  <h2 className="text-4xl font-black magma-text uppercase tracking-tighter mb-2">Synthesis Successful</h2>
                  <p className="text-zinc-400 font-medium mb-10 text-sm uppercase tracking-widest">Blueprint "{level.goalItem}" Authenticated</p>
                  
                  <div className="grid grid-cols-1 gap-4">
                    <button
                      onClick={handleNextLevel}
                      className="w-full py-4 bg-orange-500 text-zinc-950 font-black uppercase tracking-widest rounded-2xl hover:bg-orange-400 transition-all shadow-[0_0_30px_rgba(234,88,12,0.3)] active:scale-95"
                    >
                      Advance to Next Sector
                    </button>
                    <button
                      onClick={() => setIsLevelComplete(false)}
                      className="w-full py-4 bg-white/5 border border-white/10 text-zinc-400 font-black uppercase tracking-widest rounded-2xl hover:bg-white/10 transition-all active:scale-95"
                    >
                      Continue Forgery
                    </button>
                    <Link
                      to="/"
                      className="w-full py-4 text-zinc-600 font-black uppercase tracking-widest text-[10px] hover:text-zinc-400 transition-colors"
                    >
                      Return to Selection
                    </Link>
                  </div>
                </motion.div>
              </motion.div>
            )}
          </AnimatePresence>
        </main>
      </div>

      <DragOverlay dropAnimation={dropAnimation}>
        {activeItem ? (
          <motion.div
            initial={{ scale: 1, opacity: 1 }}
            animate={{ 
              scale: 1.01, 
              opacity: 1,
              boxShadow: "0 10px 30px rgba(0,0,0,0.3)"
            }}
            transition={{ duration: 0.1 }}
          >
            <ItemCard 
              name={activeItem.name} 
              isDragging 
              isMerging={!!hoveredTargetId}
            />
          </motion.div>
        ) : null}
      </DragOverlay>
    </DndContext>
  );
};

export default GameScreen;
