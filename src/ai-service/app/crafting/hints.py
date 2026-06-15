"""Suggests the next productive combination for a stuck player.

A hint is always a *real* recipe from the deterministic graph (baseline +
concept recipes), using two elements the player already owns and producing
something new -- so it is never a hallucinated combo. When the level goal is
reachable through the graph, the hint is the next step along the shortest path
toward it; otherwise it falls back to any productive combination the player can
make right now.
"""

from app.crafting.recipes import BASELINE_RECIPES, normalize_element_name
from app.crafting.semantics import CONCEPT_RECIPES

Edge = tuple[str, str, str]  # (element_a, element_b, result) with display casing


def _build_edges() -> list[Edge]:
    edges: list[Edge] = [
        (recipe.element_a, recipe.element_b, recipe.result)
        for recipe in BASELINE_RECIPES
    ]
    # CONCEPT_RECIPES is keyed by recipe_key() -> casefolded, sorted tuples.
    # Title-case them back into reasonable display names for the hint text.
    for (a_key, b_key), result in CONCEPT_RECIPES.items():
        edges.append((a_key.title(), b_key.title(), result))
    return edges


_EDGES = _build_edges()


def _cf(name: str) -> str:
    return normalize_element_name(name).casefold()


def suggest_hint(inventory: list[str], goal: str | None) -> Edge | None:
    owned = {_cf(item) for item in inventory if item and item.strip()}
    if not owned:
        return None

    # Productive recipes the player can perform right now.
    craftable = [
        edge
        for edge in _EDGES
        if _cf(edge[0]) in owned and _cf(edge[1]) in owned and _cf(edge[2]) not in owned
    ]
    if not craftable:
        return None

    if goal:
        toward_goal = _next_step_toward_goal(owned, _cf(goal))
        if toward_goal is not None:
            return toward_goal

    # No goal, or goal not reachable through the graph: any productive step.
    return craftable[0]


def _next_step_toward_goal(owned: set[str], goal_cf: str) -> Edge | None:
    if goal_cf in owned:
        return None

    # Forward closure: everything reachable from what the player owns, recording
    # one recipe that first produces each newly reachable element.
    available = set(owned)
    made_by: dict[str, Edge] = {}
    changed = True
    while changed:
        changed = False
        for edge in _EDGES:
            a, b, result = edge
            result_cf = _cf(result)
            if _cf(a) in available and _cf(b) in available and result_cf not in available:
                available.add(result_cf)
                made_by[result_cf] = edge
                changed = True

    if goal_cf not in available:
        return None

    # Walk back from the goal to the earliest prerequisite the player can craft
    # now (both inputs already owned, result not yet owned).
    def first_craftable_step(element_cf: str, seen: set[str]) -> Edge | None:
        if element_cf in seen:
            return None
        seen.add(element_cf)
        edge = made_by.get(element_cf)
        if edge is None:
            return None
        a, b, _result = edge
        for ingredient in (a, b):
            if _cf(ingredient) not in owned:
                deeper = first_craftable_step(_cf(ingredient), seen)
                if deeper is not None:
                    return deeper
        return edge

    return first_craftable_step(goal_cf, set())
