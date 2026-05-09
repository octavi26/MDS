# AI Usage Report

## Combination Engine

The AI service owns the element-combination decision for gameplay through `POST /craft`.
The backend calls this endpoint from `/api/craft` and passes the two selected elements plus session context:

- level name
- level difficulty
- goal element
- current inventory

## Deterministic Baseline

These combinations are deterministic and order-independent:

- `Fire + Water -> Steam`
- `Water + Earth -> Mud`
- `Air + Earth -> Dust`
- `Air + Water -> Rain`

Each baseline recipe includes useful-step and difficulty metadata. In this first version, that metadata is used by tests and documentation; it does not yet drive live level generation.

## Semantic Concept Recipes

The service also includes deterministic concept recipes for common alchemy-style discoveries that should feel like conceptual leaps rather than literal ingredient lists. Examples include:

- `Fire + Earth -> Lava`
- `Air + Steam -> Cloud`
- `Earth + Rain -> Plant`
- `Water + Dust -> Clay`
- `Fire + Clay -> Brick`
- `Energy + Swamp -> Life`
- `Animal + Earth -> Horse`

These recipes are intentionally authored. They keep important discoveries stable while letting the game move from primitive materials toward higher-level ideas.

## Local LLM Generation

Unknown combinations use a constrained local Ollama provider when generation is enabled.

Default settings:

- Provider: `ollama`
- Base URL: `http://localhost:11434`
- Model: `qwen2.5:0.5b-instruct`
- Timeout: 5 seconds

The prompt asks for exactly one short result name with no explanation. The model receives level and inventory context when the backend has it, so future prompts can become more goal-aware without changing the frontend contract.

## Validation Rules

Generated results are accepted only when they are concise, name-like, and useful for the game:

- 2 to 40 characters
- letters, spaces, apostrophes, or hyphens only
- not equal to either input element
- not a concatenation or reuse of meaningful input words
- not vague failure text such as `unknown`, `nothing`, `none`, or `error`

Invalid results are discarded.

## Fallback Behavior

If Ollama is unavailable, slow, disabled, or returns invalid output, the AI service returns a stable semantic fallback selected from concept categories such as air, water, earth, fire, life, and craft. The fallback deliberately avoids names that concatenate or repeat the input elements, so repeated crafting does not create long phrases like `Air Dust Earth Blend Catalyst`.

## Known Limitations

- The deterministic baseline is intentionally small and covers only classic basics.
- Guaranteed multi-step paths for advanced goals such as `Life` and `Horse` are future recipe-catalog work.
- Difficulty metadata exists in the AI service but does not yet enforce live puzzle solvability.
- TTS and companion hint generation remain separate from the combination engine.
