import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { render, screen, act } from '@testing-library/react';
import CompanionBubble from './CompanionBubble';

describe('CompanionBubble', () => {
  beforeEach(() => {
    vi.useFakeTimers();
  });

  afterEach(() => {
    vi.useRealTimers();
  });

  it('renders nothing when there is no message', () => {
    render(<CompanionBubble message={null} />);
    expect(screen.queryByRole('status')).not.toBeInTheDocument();
  });

  it('shows a message when one is provided', () => {
    render(<CompanionBubble message="Bold move." />);
    expect(screen.getByRole('status')).toHaveTextContent('Bold move.');
  });

  it('hides the bubble after visibleForMs elapses', () => {
    render(<CompanionBubble message="Bold move." visibleForMs={1000} />);
    expect(screen.getByRole('status')).toBeInTheDocument();

    act(() => {
      vi.advanceTimersByTime(1000);
    });

    expect(screen.queryByRole('status')).not.toBeInTheDocument();
  });

  it('keeps the bubble visible when visibleForMs is zero', () => {
    render(<CompanionBubble message="Forever." visibleForMs={0} />);

    act(() => {
      vi.advanceTimersByTime(60_000);
    });

    expect(screen.getByRole('status')).toHaveTextContent('Forever.');
  });

  it('replaces the displayed message when a new one arrives', () => {
    const { rerender } = render(<CompanionBubble message="First." visibleForMs={10_000} />);
    expect(screen.getByRole('status')).toHaveTextContent('First.');

    rerender(<CompanionBubble message="Second." visibleForMs={10_000} />);
    expect(screen.getByRole('status')).toHaveTextContent('Second.');
  });
});
