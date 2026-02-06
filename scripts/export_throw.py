from scripts.generate_dummy_throw import generate_dummy_throw
from scripts.serialize_throw import to_json

seq = generate_dummy_throw()
json_str = to_json(seq)

with open("data/dummy_throw.json", "w") as f:
    f.write(json_str)

print("exported")
