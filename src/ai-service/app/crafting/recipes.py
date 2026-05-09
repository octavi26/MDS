from dataclasses import dataclass


@dataclass(frozen=True)
class Recipe:
    element_a: str
    element_b: str
    result: str
    useful_steps: int
    difficulty: int


def normalize_element_name(name: str) -> str:
    return " ".join(name.strip().split())


def recipe_key(element_a: str, element_b: str) -> tuple[str, str]:
    normalized = (
        normalize_element_name(element_a).casefold(),
        normalize_element_name(element_b).casefold(),
    )
    return tuple(sorted(normalized))


BASELINE_RECIPES: tuple[Recipe, ...] = (
    Recipe("Fire", "Water", "Steam", useful_steps=1, difficulty=1),
    Recipe("Water", "Earth", "Mud", useful_steps=1, difficulty=1),
    Recipe("Air", "Earth", "Dust", useful_steps=1, difficulty=1),
    Recipe("Air", "Water", "Rain", useful_steps=1, difficulty=1),
)

RECIPES_BY_KEY = {
    recipe_key(recipe.element_a, recipe.element_b): recipe
    for recipe in BASELINE_RECIPES
}


def find_recipe(element_a: str, element_b: str) -> Recipe | None:
    return RECIPES_BY_KEY.get(recipe_key(element_a, element_b))
