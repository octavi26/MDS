import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import LevelSelectionScreen from './features/levels/LevelSelectionScreen';
import GameScreen from './features/game/GameScreen';

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Router>
        <Routes>
          <Route path="/" element={<LevelSelectionScreen />} />
          <Route path="/game/:levelId" element={<GameScreen />} />
        </Routes>
      </Router>
    </QueryClientProvider>
  );
}

export default App;
