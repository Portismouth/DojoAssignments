
def draw_stars(x):
    for item in x:
        temp = ""        
        if isinstance(item, int):
            for i in range(item):
                temp += "*"
        elif isinstance(item, str):
            for i in range(len(item)):
                temp += item[0]
        print temp
x = [10 , "hello"]
draw_stars(x) 