import React from 'react';
import { motion } from 'framer-motion';

interface SparkParticlesProps {
  x: number;
  y: number;
  onComplete: () => void;
}

const SparkParticles: React.FC<SparkParticlesProps> = ({ x, y, onComplete }) => {
  const particleCount = 20;
  const particles = Array.from({ length: particleCount });

  return (
    <div 
      className="fixed pointer-events-none z-[100]" 
      style={{ left: x, top: y }}
    >
      {particles.map((_, i) => {
        const angle = (i / particleCount) * Math.PI * 2;
        const velocity = 50 + Math.random() * 150;
        const targetX = Math.cos(angle) * velocity;
        const targetY = Math.sin(angle) * velocity;
        const size = 2 + Math.random() * 4;
        const duration = 0.5 + Math.random() * 1;

        return (
          <motion.div
            key={i}
            initial={{ x: 0, y: 0, opacity: 1, scale: 1 }}
            animate={{ 
              x: targetX, 
              y: targetY, 
              opacity: 0, 
              scale: 0,
              rotate: Math.random() * 360 
            }}
            transition={{ duration, ease: "easeOut" }}
            onAnimationComplete={i === 0 ? onComplete : undefined}
            className="absolute rounded-full bg-gradient-to-r from-orange-400 to-yellow-200"
            style={{ 
              width: size, 
              height: size,
              boxShadow: '0 0 10px rgba(251, 191, 36, 0.8)' 
            }}
          />
        );
      })}
      
      {/* Central Flash */}
      <motion.div
        initial={{ scale: 0, opacity: 1 }}
        animate={{ scale: 4, opacity: 0 }}
        transition={{ duration: 0.4 }}
        className="absolute w-10 h-10 -left-5 -top-5 rounded-full bg-white blur-xl"
      />
    </div>
  );
};

export default SparkParticles;
