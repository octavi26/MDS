import { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import LevelSelectionScreen from './features/levels/LevelSelectionScreen';
import GameScreen from './features/game/GameScreen';
import RegistrationScreen from './features/auth/RegistrationScreen';
import { apiClient } from './api/apiClient';

const queryClient = new QueryClient();

function App() {
  const [userId, setUserId] = useState<string | null>(apiClient.getUserId());

  useEffect(() => {
    const checkUser = () => {
      setUserId(apiClient.getUserId());
    };
    window.addEventListener('storage', checkUser);
    return () => window.removeEventListener('storage', checkUser);
  }, []);

  const handleRegistered = () => {
    setUserId(apiClient.getUserId());
  };

  if (!userId) {
    return (
      <QueryClientProvider client={queryClient}>
        <RegistrationScreen onRegistered={handleRegistered} />
      </QueryClientProvider>
    );
  }

  return (
    <QueryClientProvider client={queryClient}>
      <Router>
        <Routes>
          <Route path="/" element={<LevelSelectionScreen />} />
          <Route path="/game/:levelId" element={<GameScreen />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </Router>
    </QueryClientProvider>
  );
}

export default App;
