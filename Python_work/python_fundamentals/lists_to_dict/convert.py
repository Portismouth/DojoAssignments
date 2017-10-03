def make_dict(arr1, arr2):
    new_dict = {}
    if len(arr1) >= len(arr2):
        longer = arr1
        shorter = arr2
    else:
        longer = arr2
        shorter = arr1
    for (key, value) in map(None, longer, shorter):
        new_dict[key] = value
    # your code here
    return new_dict

name = ["Anna", "Eli", "Pariece", "Brendan", "Amy", "Shane", "Oscar"]
favorite_animal = ["horse", "cat", "spider", "giraffe", "ticks", "dolphins", "llamas"]

print make_dict(name, favorite_animal)