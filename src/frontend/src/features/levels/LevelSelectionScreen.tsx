import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
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
      <div className="min-h-screen bg-zinc-950 text-zinc-100 flex items-center justify-center">
        <div className="text-xl animate-pulse">Loading levels...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="min-h-screen bg-zinc-950 text-red-400 flex items-center justify-center">
        <div className="text-xl">Error loading levels. Is the backend running?</div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-zinc-950 text-zinc-100 p-8">
      <div className="max-w-4xl mx-auto">
        <header className="mb-12 text-center">
          <h1 className="text-4xl font-bold tracking-tight mb-4">Craft Game</h1>
          <p className="text-zinc-400">Select a level to start your crafting journey</p>
        </header>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {levels?.map((level: Level) => (
            <div
              key={level.id}
              onClick={() => navigate(`/game/${level.id}`)}
              className="group relative bg-zinc-900 border border-zinc-800 p-6 rounded-xl cursor-pointer hover:border-zinc-600 transition-all hover:bg-zinc-800/50"
            >
              <div className="flex flex-col h-full justify-between">
                <div>
                  <h2 className="text-xl font-semibold mb-2 group-hover:text-blue-400 transition-colors">
                    {level.name}
                  </h2>
                  <p className="text-sm text-zinc-500 mb-4">Goal: <span className="text-zinc-300 font-medium">{level.goalItem}</span></p>
                </div>
                
                <div className="flex flex-wrap gap-2">
                  {level.startingItems.slice(0, 4).map((item) => (
                    <span 
                      key={item} 
                      className="px-2 py-1 bg-zinc-800 text-zinc-400 text-xs rounded border border-zinc-700"
                    >
                      {item}
                    </span>
                  ))}
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default LevelSelectionScreen;
