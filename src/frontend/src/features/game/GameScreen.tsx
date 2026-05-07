import React, { useState, useEffect, useRef } from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import {
  DndContext,
  useSensor,
  useSensors,
  PointerSensor,
  DragOverlay,
  defaultDropAnimationSideEffects
} from '@dnd-kit/core';
import type { DragEndEvent, DragStartEvent, DropAnimation } from '@dnd-kit/core';
import { ChevronLeft, Loader2 } from 'lucide-react';
import { useQuery, useMutation } from '@tanstack/react-query';
import { apiClient } from '../../api/apiClient';
import InventorySidebar from './InventorySidebar';
import CraftingCanvas from './CraftingCanvas';
import ItemCard from './ItemCard';
import CompanionBubble from './CompanionBubble';
import { useGameStore } from './gameStore';
import { useCompanion } from './useCompanion';

const USER_ID = 'a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d';

const dropAnimation: DropAnimation = {
  sideEffects: defaultDropAnimationSideEffects({
    styles: {
      active: {
        opacity: '0.5',
      },
    },
  }),
};

const GameScreen: React.FC = () => {
  const { levelId } = useParams<{ levelId: string }>();
  const navigate = useNavigate();
  const { addItem, updateItemPosition, canvasItems } = useGameStore();
  const [activeItem, setActiveItem] = useState<{ id: string, name: string, type: string } | null>(null);
  const [sessionId, setSessionId] = useState<string | null>(null);
  const [apiCompanionMessage, setApiCompanionMessage] = useState<string | null>(null);

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
      startSessionMutation.mutate({ userId: USER_ID, lId: levelId });
    }
  }, [levelId, sessionId]);

  const { data: sessionData, isLoading: sessionLoading } = useQuery({
    queryKey: ['session', sessionId],
    queryFn: () => apiClient.getSession(sessionId!),
    enabled: !!sessionId,
  });

  const localCompanion = useCompanion({
    levelName: level?.name,
    goalName: level?.goalItem,
    inventory: level?.startingItems ?? [],
  });

  // Use API message if available (on start), otherwise use local companion logic
  const currentCompanionMessage = apiCompanionMessage || localCompanion.message;

  const previousCanvasCountRef = useRef(0);
  useEffect(() => {
    const previous = previousCanvasCountRef.current;
    if (previous > 0 && canvasItems.length === 0) {
      localCompanion.notifyCanvasCleared();
      setApiCompanionMessage(null); // Switch to local logic after first interaction
    }
    previousCanvasCountRef.current = canvasItems.length;
  }, [canvasItems.length, localCompanion]);

  const sensors = useSensors(
    useSensor(PointerSensor, {
      activationConstraint: {
        distance: 5,
      },
    })
  );

  const handleDragStart = (event: DragStartEvent) => {
    const { active } = event;
    const data = active.data.current;
    if (data) {
      setActiveItem({ id: active.id as string, name: data.name, type: data.type });
    }
  };

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over, delta } = event;
    setActiveItem(null);

    if (!over || over.id !== 'crafting-canvas') return;

    const data = active.data.current;
    if (!data) return;

    const canvasElement = document.querySelector('[ref-id="crafting-canvas-container"]');
    if (!canvasElement) return;
    
    const rect = canvasElement.getBoundingClientRect();

    if (data.type === 'inventory') {
      const clientX = (event.activatorEvent as MouseEvent).clientX + delta.x;
      const clientY = (event.activatorEvent as MouseEvent).clientY + delta.y;
      
      const x = clientX - rect.left - 50; 
      const y = clientY - rect.top - 25; 
      
      addItem(data.name, x, y);
      localCompanion.notifyElementAdded(data.name);
      setApiCompanionMessage(null); // Switch to local logic after first interaction
    } else if (data.type === 'canvas') {
      const item = canvasItems.find((i) => i.id === data.originId);
      if (item) {
        updateItemPosition(item.id, item.x + delta.x, item.y + delta.y);
      }
    }
  };

  if (levelsLoading || (sessionId && sessionLoading)) {
    return (
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex items-center justify-center">
        <Loader2 className="animate-spin mr-2" />
        <span>Loading Game...</span>
      </div>
    );
  }

  if (!level) {
    return (
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex flex-col items-center justify-center p-8">
        <div className="text-center">
          <h1 className="text-3xl font-bold mb-4">Level Not Found</h1>
          <p className="text-zinc-400 mb-8">The level you are looking for does not exist.</p>
          <button
            onClick={() => navigate('/')}
            className="px-6 py-2 bg-zinc-100 text-zinc-950 font-semibold rounded-lg hover:bg-zinc-300 transition-colors"
          >
            Back to Levels
          </button>
        </div>
      </div>
    );
  }

  const inventoryItems = sessionData?.inventory.map(i => i.name) || level.startingItems;

  return (
    <DndContext 
      sensors={sensors} 
      onDragStart={handleDragStart}
      onDragEnd={handleDragEnd}
    >
      <div className="h-screen flex flex-col bg-zinc-950 text-zinc-100 overflow-hidden">
        <header className="h-16 border-b border-zinc-800 bg-zinc-900/50 flex items-center justify-between px-6 shrink-0 z-20">
          <div className="flex items-center gap-4">
            <Link 
              to="/" 
              className="p-2 hover:bg-zinc-800 rounded-lg transition-colors text-zinc-400 hover:text-zinc-100"
              title="Back to Levels"
            >
              <ChevronLeft size={20} />
            </Link>
            <div>
              <h1 className="text-lg font-bold leading-tight">{level.name}</h1>
              <p className="text-xs text-zinc-500 uppercase tracking-wider font-semibold">Mission</p>
            </div>
          </div>

          <div className="bg-zinc-800 px-4 py-2 rounded-lg border border-zinc-700 flex items-center gap-3">
            <span className="text-xs text-zinc-400 font-medium">Goal:</span>
            <span className="text-sm font-bold text-blue-400">{level.goalItem}</span>
          </div>

          <div className="w-10 h-10 rounded-full bg-zinc-800 border border-zinc-700 flex items-center justify-center text-xs font-bold">
            P1
          </div>
        </header>

        <main className="flex-1 flex overflow-hidden relative">
          <InventorySidebar items={inventoryItems} />
          <CraftingCanvas />
          
          <div className="absolute bottom-10 left-72 z-40">
            <CompanionBubble message={currentCompanionMessage} />
          </div>
        </main>
      </div>

      <DragOverlay dropAnimation={dropAnimation}>
        {activeItem ? (
          <ItemCard name={activeItem.name} isDragging />
        ) : null}
      </DragOverlay>
    </DndContext>
  );
};

export default GameScreen;
