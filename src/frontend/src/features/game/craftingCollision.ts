import type { CanvasItem } from './gameStore';

export const CANVAS_ITEM_WIDTH = 120;
export const CANVAS_ITEM_HEIGHT = 56;
const MIN_OVERLAP_AREA = 900;

interface Rect {
  x: number;
  y: number;
  width: number;
  height: number;
}

export const findOverlappingCanvasItem = (
  movingItem: CanvasItem,
  finalX: number,
  finalY: number,
  canvasItems: CanvasItem[],
): CanvasItem | null => {
  const movingRect = toRect(finalX, finalY);

  return canvasItems
    .filter((item) => item.id !== movingItem.id)
    .map((item) => ({
      item,
      overlapArea: overlapArea(movingRect, toRect(item.x, item.y)),
    }))
    .filter(({ overlapArea }) => overlapArea >= MIN_OVERLAP_AREA)
    .sort((a, b) => b.overlapArea - a.overlapArea)[0]?.item ?? null;
};

const toRect = (x: number, y: number): Rect => ({
  x,
  y,
  width: CANVAS_ITEM_WIDTH,
  height: CANVAS_ITEM_HEIGHT,
});

const overlapArea = (a: Rect, b: Rect): number => {
  const xOverlap = Math.max(0, Math.min(a.x + a.width, b.x + b.width) - Math.max(a.x, b.x));
  const yOverlap = Math.max(0, Math.min(a.y + a.height, b.y + b.height) - Math.max(a.y, b.y));
  return xOverlap * yOverlap;
};
