from scripts.generate_dummy_throw import generate_dummy_throw
from scripts.serialize_throw import to_json

seq = generate_dummy_throw()
json_str = to_json(seq)

print(json_str[:300])