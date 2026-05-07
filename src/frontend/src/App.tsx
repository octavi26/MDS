import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LevelSelectionScreen from './features/levels/LevelSelectionScreen';
import GameScreen from './features/game/GameScreen';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LevelSelectionScreen />} />
        <Route path="/game/:levelId" element={<GameScreen />} />
      </Routes>
    </Router>
  );
}

export default App;
