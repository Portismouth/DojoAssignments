class Math(object):
    def __init__(self, value=0):
        self.value = value
    def add(self, *args):
        total = 0
        for item in args:
            if isinstance(item, list):
                total += sum(item)
            elif isinstance(item, tuple):
                total += sum(item)
            else:
                total += item
        self.value += total
        return self
    def subtract(self, *args):
        total = 0
        for item in args:
            if isinstance(item, list):
                total += sum(item)
            elif isinstance(item, tuple):
                total += sum(item)
            else:
                total += item
        self.value -= total
        return self
    def result(self):
        return self.value


md = Math()
x = md.add([1,2,3],2,(1,2)).add(2, 5).subtract([5,6,7], 5).result()
print x
