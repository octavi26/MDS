from pydantic import BaseModel, ConfigDict, Field


class CraftRequest(BaseModel):
    model_config = ConfigDict(populate_by_name=True)

    element_a: str = Field(min_length=1)
    element_b: str = Field(min_length=1)
    level_name: str | None = None
    level_difficulty: int | None = Field(default=None, ge=1)
    goal_element: str | None = None
    inventory: list[str] = Field(default_factory=list)


class CraftResponse(BaseModel):
    result: str
    source: str
    deterministic: bool
    useful_steps: int | None = None
    difficulty: int | None = None


class HintRequest(BaseModel):
    inventory: list[str] = Field(default_factory=list)
    goal: str | None = None


class HintResponse(BaseModel):
    found: bool
    element_a: str | None = None
    element_b: str | None = None
    result: str | None = None
