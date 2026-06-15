import { describe, it, expect, vi } from 'vitest'
import { render, screen } from '@testing-library/react'
import App from './App'

// Mock the apiClient
vi.mock('./api/apiClient', () => ({
  apiClient: {
    getUserId: vi.fn().mockReturnValue('test-user-id'),
    getUsername: vi.fn().mockReturnValue('TestPlayer'),
    getLevels: vi.fn().mockResolvedValue([
      {
        id: '1',
        name: 'The First Step',
        description: 'Combine elements to create Steam!',
        difficulty: 1,
        goalItem: 'Steam',
        startingItems: ['Water', 'Fire']
      },
      {
        id: '2',
        name: "Nature's Recipe",
        description: 'Create Mud and Rain to progress.',
        difficulty: 2,
        goalItem: 'Rain',
        startingItems: ['Water', 'Fire', 'Earth', 'Air']
      }
    ]),
    startSession: vi.fn().mockResolvedValue({ sessionId: 'test-session-id' }),
    getSession: vi.fn().mockResolvedValue({
      id: 'test-session-id',
      levelId: '1',
      inventory: [{ name: 'Water', quantity: 1 }, { name: 'Fire', quantity: 1 }]
    }),
    getCompanionComment: vi.fn().mockResolvedValue({ comment: 'Hello tester!' })
  }
}))

describe('App', () => {
  it('renders the level selection screen', async () => {
    render(<App />)

    expect(await screen.findByText('Mocking Forge')).toBeInTheDocument()
    expect(await screen.findByText('Neural Synthesis & Material Forgery')).toBeInTheDocument()
  })

  it('renders loaded levels', async () => {
    render(<App />)
    
    expect((await screen.findAllByText('The First Step')).length).toBeGreaterThan(0)
    expect((await screen.findAllByText("Nature's Recipe")).length).toBeGreaterThan(0)
  })
})
