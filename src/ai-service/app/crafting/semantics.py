from app.crafting.recipes import normalize_element_name, recipe_key

GENERIC_RESULT_WORDS = {
    "blend",
    "catalyst",
    "compound",
    "essence",
    "mixture",
}

CONCEPT_RECIPES: dict[tuple[str, str], str] = {
    recipe_key("Air", "Air"): "Wind",
    recipe_key("Water", "Water"): "Lake",
    recipe_key("Earth", "Earth"): "Stone",
    recipe_key("Fire", "Fire"): "Energy",
    recipe_key("Fire", "Earth"): "Lava",
    recipe_key("Air", "Fire"): "Energy",
    recipe_key("Air", "Steam"): "Cloud",
    recipe_key("Water", "Steam"): "Cloud",
    recipe_key("Air", "Cloud"): "Sky",
    recipe_key("Water", "Cloud"): "Rain",
    recipe_key("Earth", "Rain"): "Plant",
    recipe_key("Water", "Plant"): "Algae",
    recipe_key("Earth", "Plant"): "Forest",
    recipe_key("Fire", "Plant"): "Ash",
    recipe_key("Fire", "Dust"): "Ash",
    recipe_key("Water", "Dust"): "Clay",
    recipe_key("Fire", "Clay"): "Brick",
    recipe_key("Water", "Mud"): "Swamp",
    recipe_key("Plant", "Mud"): "Life",
    recipe_key("Energy", "Swamp"): "Life",
    recipe_key("Energy", "Mud"): "Life",
    recipe_key("Life", "Earth"): "Animal",
    recipe_key("Life", "Water"): "Fish",
    recipe_key("Life", "Air"): "Bird",
    recipe_key("Life", "Fire"): "Phoenix",
    recipe_key("Animal", "Earth"): "Horse",
    recipe_key("Animal", "Human"): "Companion",
    recipe_key("Life", "Tool"): "Human",
    recipe_key("Animal", "Tool"): "Human",
    recipe_key("Stone", "Fire"): "Metal",
    recipe_key("Metal", "Fire"): "Tool",
    recipe_key("Metal", "Human"): "Machine",
    recipe_key("Brick", "Tool"): "House",
    recipe_key("House", "Human"): "Village",
    # --- Level progression recipes ---------------------------------------
    # These MUST match what each mission's description tells the player to do
    # (see the Level seed in CraftGameDbContext.cs). Without them, the "correct"
    # combination falls through to the LLM and produces a wrong, hallucinated
    # element, making the level unsolvable. Keep this block in sync with the
    # levels.
    recipe_key("Fire", "Mud"): "Stone",      # Solid Base: "bake a Stone"
    recipe_key("Metal", "Wood"): "Tool",     # Tools of Trade: "Metal and Wood -> Tool"
    recipe_key("Tool", "Wood"): "Wheel",     # The Wheel: "A Tool and Wood -> Wheel"
    recipe_key("Steam", "Metal"): "Engine",  # The Engine: "Steam power and Metal -> Engine"
    recipe_key("Engine", "Wheel"): "Car",    # Transportation: "Engine and Wheels -> Car"
    recipe_key("Life", "DNA"): "Human",      # Biotechnology: "Life into DNA -> Human"
    recipe_key("Human", "Robot"): "Cyborg",  # The Singularity: "Human and Robot -> Cyborg"
}

CATEGORY_KEYWORDS: dict[str, set[str]] = {
    "air": {"air", "wind", "sky", "cloud", "storm", "weather"},
    "water": {"water", "rain", "lake", "river", "ocean", "steam", "swamp", "fish"},
    "earth": {"earth", "dust", "mud", "stone", "clay", "brick", "lava", "metal"},
    "fire": {"fire", "ash", "lava", "ember", "spark", "energy", "phoenix"},
    "life": {"life", "plant", "forest", "algae", "animal", "bird", "horse", "human"},
    "craft": {"tool", "house", "village", "machine", "companion"},
}

CATEGORY_RESULTS: dict[tuple[str, str], tuple[str, ...]] = {
    ("air", "air"): ("Wind", "Pressure", "Gust"),
    ("air", "craft"): ("Signal", "Map", "Compass"),
    ("air", "earth"): ("Dust", "Sand", "Dune"),
    ("air", "fire"): ("Energy", "Lightning", "Heat"),
    ("air", "life"): ("Bird", "Breath", "Pollen"),
    ("air", "water"): ("Weather", "Cloud", "Mist"),
    ("craft", "craft"): ("Machine", "Workshop", "Industry"),
    ("craft", "earth"): ("Tool", "Pottery", "Road"),
    ("craft", "fire"): ("Forge", "Engine", "Kiln"),
    ("craft", "life"): ("Human", "Culture", "Farmer"),
    ("craft", "water"): ("Canal", "Boat", "Mill"),
    ("earth", "earth"): ("Stone", "Mountain", "Cave"),
    ("earth", "fire"): ("Lava", "Metal", "Glass"),
    ("earth", "life"): ("Forest", "Animal", "Farm"),
    ("earth", "water"): ("Mud", "Clay", "Island"),
    ("fire", "fire"): ("Energy", "Heat", "Light"),
    ("fire", "life"): ("Ash", "Phoenix", "Cooked Food"),
    ("fire", "water"): ("Steam", "Pressure", "Mist"),
    ("life", "life"): ("Animal", "Family", "Society"),
    ("life", "water"): ("Fish", "Algae", "Garden"),
    ("water", "water"): ("Lake", "River", "Ocean"),
}

DEFAULT_CONCEPTS = (
    "Discovery",
    "Tool",
    "Signal",
    "Pattern",
    "Machine",
    "Habitat",
    "Resource",
    "Artifact",
)


def find_concept_recipe(element_a: str, element_b: str) -> str | None:
    return CONCEPT_RECIPES.get(recipe_key(element_a, element_b))


def semantic_fallback_result(element_a: str, element_b: str) -> str:
    categories = sorted((_category_for(element_a), _category_for(element_b)))
    candidates = CATEGORY_RESULTS.get(tuple(categories), DEFAULT_CONCEPTS)
    blocked_tokens = _meaningful_tokens(element_a) | _meaningful_tokens(element_b)

    for offset in range(len(candidates)):
        candidate = candidates[(_stable_index(element_a, element_b) + offset) % len(candidates)]
        if _meaningful_tokens(candidate).isdisjoint(blocked_tokens):
            return candidate

    for candidate in DEFAULT_CONCEPTS:
        if _meaningful_tokens(candidate).isdisjoint(blocked_tokens):
            return candidate

    return "Discovery"


def result_reuses_input_concept(result: str, element_a: str, element_b: str) -> bool:
    result_tokens = _meaningful_tokens(result)
    input_tokens = _meaningful_tokens(element_a) | _meaningful_tokens(element_b)
    return not result_tokens.isdisjoint(input_tokens)


def _category_for(element: str) -> str:
    tokens = _meaningful_tokens(element)
    for category, keywords in CATEGORY_KEYWORDS.items():
        if not tokens.isdisjoint(keywords):
            return category

    return "craft"


def _meaningful_tokens(element: str) -> set[str]:
    words = normalize_element_name(element).casefold().replace("-", " ").split()
    return {word for word in words if word and word not in GENERIC_RESULT_WORDS}


def _stable_index(element_a: str, element_b: str) -> int:
    key = "|".join(recipe_key(element_a, element_b))
    return sum(ord(char) for char in key)
