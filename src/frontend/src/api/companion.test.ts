import { afterEach, beforeEach, describe, expect, it, vi } from 'vitest';
import { requestCompanionComment } from './companion';

describe('requestCompanionComment', () => {
  const baseUrl = 'http://test.local';

  beforeEach(() => {
    vi.spyOn(globalThis, 'fetch');
  });

  afterEach(() => {
    vi.restoreAllMocks();
  });

  it('returns the parsed comment on a successful response', async () => {
    (globalThis.fetch as unknown as ReturnType<typeof vi.fn>).mockResolvedValueOnce(
      new Response(
        JSON.stringify({
          text: 'Bold move.',
          eventType: 'FirstDiscovery',
          source: 'deterministic-fallback',
          voiceLineUrl: null,
        }),
        { status: 200, headers: { 'Content-Type': 'application/json' } },
      ),
    );

    const result = await requestCompanionComment(
      {
        eventType: 'FirstDiscovery',
        elementName: 'Steam',
        levelName: 'Basics',
        goalName: 'Steam',
        inventory: ['Water', 'Fire'],
        moveCount: 2,
      },
      { baseUrl },
    );

    expect(result?.text).toBe('Bold move.');
    expect(result?.source).toBe('deterministic-fallback');

    const fetchMock = globalThis.fetch as unknown as ReturnType<typeof vi.fn>;
    const [url, init] = fetchMock.mock.calls[0];
    expect(url).toBe(`${baseUrl}/api/companion/comments`);
    expect((init as RequestInit).method).toBe('POST');
    const body = JSON.parse(((init as RequestInit).body as string) ?? '{}');
    expect(body.eventType).toBe('FirstDiscovery');
    expect(body.elementName).toBe('Steam');
  });

  it('returns null on a non-2xx response', async () => {
    (globalThis.fetch as unknown as ReturnType<typeof vi.fn>).mockResolvedValueOnce(
      new Response('boom', { status: 500 }),
    );

    const result = await requestCompanionComment(
      {
        eventType: 'FailedCombination',
        inventory: [],
        moveCount: 0,
      },
      { baseUrl },
    );

    expect(result).toBeNull();
  });

  it('returns null when the response payload has no text', async () => {
    (globalThis.fetch as unknown as ReturnType<typeof vi.fn>).mockResolvedValueOnce(
      new Response(JSON.stringify({ text: '', source: 'ollama' }), {
        status: 200,
        headers: { 'Content-Type': 'application/json' },
      }),
    );

    const result = await requestCompanionComment(
      {
        eventType: 'FailedCombination',
        inventory: [],
        moveCount: 0,
      },
      { baseUrl },
    );

    expect(result).toBeNull();
  });

  it('returns null when fetch throws a network error', async () => {
    (globalThis.fetch as unknown as ReturnType<typeof vi.fn>).mockRejectedValueOnce(
      new TypeError('Failed to fetch'),
    );

    const result = await requestCompanionComment(
      {
        eventType: 'FailedCombination',
        inventory: [],
        moveCount: 0,
      },
      { baseUrl },
    );

    expect(result).toBeNull();
  });

  it('propagates AbortError from the caller', async () => {
    (globalThis.fetch as unknown as ReturnType<typeof vi.fn>).mockRejectedValueOnce(
      Object.assign(new Error('aborted'), { name: 'AbortError' }),
    );

    await expect(
      requestCompanionComment(
        {
          eventType: 'FailedCombination',
          inventory: [],
          moveCount: 0,
        },
        { baseUrl },
      ),
    ).rejects.toMatchObject({ name: 'AbortError' });
  });
});
