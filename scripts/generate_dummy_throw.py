import numpy as np
from core.types import Frame, ThrowSequence

def generate_dummy_throw(n_frames=120):
    frames = []
    for i in range(n_frames):
        t = i/120.0
        wrist_q=np.array([0, 0, np.sin(t), np.cos(t)])
        frames.append(
            Frame(
                t=t,
                joints={
                    "shoulder": np.array([0, 0, 0, 1]),
                    "elbow": np.array([0, 0, 0, 1]),
                    "wrist": wrist_q,
                }
            )
        )
    return ThrowSequence(frames=frames, release_frame_idx=60)