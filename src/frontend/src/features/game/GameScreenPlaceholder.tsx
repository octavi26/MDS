import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

const GameScreenPlaceholder: React.FC = () => {
  const { levelId } = useParams<{ levelId: string }>();
  const navigate = useNavigate();

  return (
    <div className="min-h-screen bg-zinc-950 text-zinc-100 flex flex-col items-center justify-center p-8">
      <div className="bg-zinc-900 border border-zinc-800 p-8 rounded-2xl shadow-2xl max-w-md w-full text-center">
        <h1 className="text-2xl font-bold mb-6">Level: {levelId}</h1>
        <p className="text-zinc-400 mb-8 italic">
          Game Interface for Level: [{levelId}] coming soon...
        </p>
        <button
          onClick={() => navigate('/')}
          className="w-full py-3 bg-zinc-100 text-zinc-950 font-semibold rounded-lg hover:bg-zinc-300 transition-colors"
        >
          Back to Levels
        </button>
      </div>
    </div>
  );
};

export default GameScreenPlaceholder;
