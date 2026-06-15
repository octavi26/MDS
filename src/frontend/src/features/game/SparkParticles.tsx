import React, { useMemo } from 'react';
import { motion } from 'framer-motion';

interface SparkParticlesProps {
  x: number;
  y: number;
  onComplete: () => void;
}

const deterministicUnit = (seed: number) => {
  const value = Math.sin(seed * 12.9898) * 43758.5453;
  return value - Math.floor(value);
};

const SparkParticles: React.FC<SparkParticlesProps> = ({ x, y, onComplete }) => {
  const particleCount = 10; // Reduced from 20 to improve performance
  const particles = useMemo(() => (
    Array.from({ length: particleCount }, (_, i) => {
      const angle = (i / particleCount) * Math.PI * 2;
      const velocity = 40 + deterministicUnit(i + 1) * 100;

      return {
        id: i,
        targetX: Math.cos(angle) * velocity,
        targetY: Math.sin(angle) * velocity,
        size: 2 + deterministicUnit(i + 11) * 3,
        duration: 0.4 + deterministicUnit(i + 21) * 0.4,
      };
    })
  ), []);

  return (
    <div 
      className="fixed pointer-events-none z-[100]" 
      style={{ left: x, top: y }}
    >
      {particles.map((particle, i) => {
        return (
          <motion.div
            key={particle.id}
            initial={{ x: 0, y: 0, opacity: 1, scale: 1 }}
            animate={{ 
              x: particle.targetX, 
              y: particle.targetY, 
              opacity: 0, 
              scale: 0
            }}
            transition={{ duration: particle.duration, ease: "linear" }} // Use linear for less CPU load
            onAnimationComplete={i === 0 ? onComplete : undefined}
            className="absolute rounded-full bg-orange-400"
            style={{ 
              width: particle.size, 
              height: particle.size,
              willChange: 'transform, opacity' // Performance hint
            }}
          />
        );
      })}
    </div>
  );
};

export default SparkParticles;
