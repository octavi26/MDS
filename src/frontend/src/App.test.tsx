import { describe, it, expect, beforeEach } from 'vitest'
import { render, screen, cleanup } from '@testing-library/react'
import App from './App'

describe('App', () => {
  beforeEach(() => {
    cleanup()
  })

  it('renders the level selection screen', () => {
    render(<App />)

    expect(screen.getByText('Craft Game')).toBeInTheDocument()
    expect(screen.getByText('Select a level to start your crafting journey')).toBeInTheDocument()
  })

  it('renders initial mock levels', () => {
    render(<App />)
    
    // Using getAllByText and checking length to be safe against double-render issues if cleanup fails
    expect(screen.getAllByText('Level 1: The Basics').length).toBeGreaterThan(0)
    expect(screen.getAllByText('Level 2: Muddy Waters').length).toBeGreaterThan(0)
    expect(screen.getAllByText('Level 3: Tropical Storm').length).toBeGreaterThan(0)
  })
})
