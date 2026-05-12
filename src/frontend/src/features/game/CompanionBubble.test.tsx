import { describe, expect, it } from 'vitest';
import { render, screen, fireEvent } from '@testing-library/react';
import CompanionBubble, { type ChatMessage } from './CompanionBubble';

const mockMessages: ChatMessage[] = [
  { id: '1', text: 'First message', sender: 'ai', timestamp: new Date() },
  { id: '2', text: 'Second message', sender: 'ai', timestamp: new Date() },
];

describe('CompanionBubble', () => {
  it('renders only the last message as a preview when closed', () => {
    render(<CompanionBubble messages={mockMessages} />);
    expect(screen.getByText('Second message')).toBeInTheDocument();
    expect(screen.queryByText('First message')).not.toBeInTheDocument();
  });

  it('renders nothing if messages array is empty', () => {
    render(<CompanionBubble messages={[]} />);
    // Should still render the avatar button
    expect(screen.getByRole('button')).toBeInTheDocument();
    // But no bubble preview (the preview div has bg-zinc-100)
    const preview = screen.queryByText(/message/i);
    expect(preview).not.toBeInTheDocument();
  });

  it('toggles the chat history panel when avatar is clicked', () => {
    render(<CompanionBubble messages={mockMessages} />);
    const button = screen.getByRole('button');
    
    // Open
    fireEvent.click(button);
    expect(screen.getByText('Forge Logs')).toBeInTheDocument();
    expect(screen.getByText('First message')).toBeInTheDocument();
    expect(screen.getByText('Second message')).toBeInTheDocument();

    // Close
    fireEvent.click(button);
    expect(screen.queryByText('Forge Logs')).not.toBeInTheDocument();
  });

  it('shows the message count badge when closed', () => {
    render(<CompanionBubble messages={mockMessages} />);
    expect(screen.getByText('2')).toBeInTheDocument();
  });
});
