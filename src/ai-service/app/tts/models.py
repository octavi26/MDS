from pydantic import BaseModel, Field


class TtsRequest(BaseModel):
    text: str = Field(..., min_length=1, max_length=600)


class TtsResponse(BaseModel):
    url: str
