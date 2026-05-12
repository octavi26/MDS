import type { CanvasItem } from './gameStore';

export const CANVAS_ITEM_WIDTH = 120;
export const CANVAS_ITEM_HEIGHT = 56;

// Make detection very forgiving and "sticky" by using distance to center
// and a generous bounding box expansion.
const EXPAND_RADIUS = 30; 

export const findOverlappingCanvasItem = (
  movingItem: { id: string; x: number; y: number; name: string },
  finalX: number,
  finalY: number,
  canvasItems: CanvasItem[],
): CanvasItem | null => {
  const centerX = finalX + CANVAS_ITEM_WIDTH / 2;
  const centerY = finalY + CANVAS_ITEM_HEIGHT / 2;

  let closestItem: CanvasItem | null = null;
  let minDistance = Infinity;

  for (const item of canvasItems) {
    if (item.id === movingItem.id) continue;

    const itemCenterX = item.x + CANVAS_ITEM_WIDTH / 2;
    const itemCenterY = item.y + CANVAS_ITEM_HEIGHT / 2;
    
    // Check if the center of the dragged item is within the target item's area
    // plus a small expansion for 'stickiness'
    if (
      centerX >= item.x - EXPAND_RADIUS &&
      centerX <= item.x + CANVAS_ITEM_WIDTH + EXPAND_RADIUS &&
      centerY >= item.y - EXPAND_RADIUS &&
      centerY <= item.y + CANVAS_ITEM_HEIGHT + EXPAND_RADIUS
    ) {
      const dist = Math.sqrt(Math.pow(centerX - itemCenterX, 2) + Math.pow(centerY - itemCenterY, 2));
      if (dist < minDistance) {
        minDistance = dist;
        closestItem = item;
      }
    }
  }

  return closestItem;
};
