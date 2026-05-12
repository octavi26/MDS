import { describe, expect, it } from 'vitest';
import { findOverlappingCanvasItem } from './craftingCollision';
import type { CanvasItem } from './gameStore';

describe('findOverlappingCanvasItem', () => {
  const water: CanvasItem = { id: 'water-1', name: 'Water', x: 100, y: 100 };
  const fire: CanvasItem = { id: 'fire-1', name: 'Fire', x: 300, y: 100 };

  it('returns the item overlapped by the moving item', () => {
    const result = findOverlappingCanvasItem(fire, 110, 105, [water, fire]);

    expect(result).toBe(water);
  });

  it('ignores tiny edge overlaps', () => {
    const result = findOverlappingCanvasItem(fire, 210, 100, [water, fire]);

    expect(result).toBeNull();
  });

  it('ignores the moving item itself', () => {
    const result = findOverlappingCanvasItem(water, 100, 100, [water]);

    expect(result).toBeNull();
  });
});
