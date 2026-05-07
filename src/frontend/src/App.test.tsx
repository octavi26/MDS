import { describe, it, expect } from 'vitest'
import { render, screen } from '@testing-library/react'
import App from './App'

describe('App', () => {
  it('renders the level selection screen', () => {
    render(<App />)

    expect(screen.getByText('Craft Game')).toBeInTheDocument()
    expect(screen.getByText('Select a level to start your crafting journey')).toBeInTheDocument()
  })

  it('renders initial mock levels', () => {
    render(<App />)
    
    expect(screen.getByText('Level 1: The Basics')).toBeInTheDocument()
    expect(screen.getByText('Level 2: Muddy Waters')).toBeInTheDocument()
    expect(screen.getByText('Level 3: Tropical Storm')).toBeInTheDocument()
  })
})
