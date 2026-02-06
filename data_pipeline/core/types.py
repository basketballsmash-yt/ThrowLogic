from dataclasses import dataclass
from typing import Dict
import numpy as np

@dataclass
class Frame:
    t: float
    joints: Dict[str, np.ndarray]

@dataclass
class ThrowSequence:
    frames: list[Frame]
    release_frame_idx: int
