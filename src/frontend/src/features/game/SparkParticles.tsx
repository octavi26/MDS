import React from 'react';
import { motion } from 'framer-motion';

interface SparkParticlesProps {
  x: number;
  y: number;
  onComplete: () => void;
}

const SparkParticles: React.FC<SparkParticlesProps> = ({ x, y, onComplete }) => {
  const particleCount = 10; // Reduced from 20 to improve performance
  const particles = Array.from({ length: particleCount });

  return (
    <div 
      className="fixed pointer-events-none z-[100]" 
      style={{ left: x, top: y }}
    >
      {particles.map((_, i) => {
        const angle = (i / particleCount) * Math.PI * 2;
        const velocity = 40 + Math.random() * 100;
        const targetX = Math.cos(angle) * velocity;
        const targetY = Math.sin(angle) * velocity;
        const size = 2 + Math.random() * 3;
        const duration = 0.4 + Math.random() * 0.4;

        return (
          <motion.div
            key={i}
            initial={{ x: 0, y: 0, opacity: 1, scale: 1 }}
            animate={{ 
              x: targetX, 
              y: targetY, 
              opacity: 0, 
              scale: 0
            }}
            transition={{ duration, ease: "linear" }} // Use linear for less CPU load
            onAnimationComplete={i === 0 ? onComplete : undefined}
            className="absolute rounded-full bg-orange-400"
            style={{ 
              width: size, 
              height: size,
              willChange: 'transform, opacity' // Performance hint
            }}
          />
        );
      })}
    </div>
  );
};

export default SparkParticles;
