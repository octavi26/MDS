import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LevelSelectionScreen from './features/levels/LevelSelectionScreen';
import GameScreenPlaceholder from './features/game/GameScreenPlaceholder';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LevelSelectionScreen />} />
        <Route path="/game/:levelId" element={<GameScreenPlaceholder />} />
      </Routes>
    </Router>
  );
}

export default App;
