import json

def to_json(seq):
    return json.dumps({
        "frames": [
            {
                "t": f.t,
                "joints": {k: v.tolist() for k, v in f.joints.items()}
            } for f in seq.frames
        ],
        "release_frame_idx": seq.release_frame_idx
    })