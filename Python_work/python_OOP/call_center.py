class Call(object):
    def __init__(self, id_number, name, number, time, reason):
        self.id_number = id_number
        self.name = name
        self.number = number
        self.time = time
        self.reason = reason
    def display(self):
        print "ID: {}\nName: {}\nNumber: {}\nTime: {}\nReason: {}\n".format(self.id_number, self.name, self.number, self.time, self.reason)
        return self

class CallCenter(object):
    def __init__(self):
        self.calls = []
        self.wait_list = len(self.calls)
    def add(self, call):
        self.calls.append(call)
        return self
    def remove(self):
        self.calls.pop(0)
        return self
    def remove_number(self, number):
        for item in self.calls:
            if number == item.number:
                del self.calls[self.calls.index(item)]
        return self
    def sort(self):
        self.calls.sort()
        return self
    def info(self):
        for info in self.calls:
            info.display()
        return self

call1 = Call(1,"Mitchell","435-680-8818","151","help")
call2 = Call(2,"Mitc","435-680-8828","251","hi")
call3 = Call(3,"Mit","435-680-8838","351","hi")
call4 = Call(4,"Mitch","435-680-8848","451","help")
call5 = Call(5,"Mitchel","435-680-8858","551","hi")

center = CallCenter()
center.add(call1).add(call3).remove().add(call2).remove_number("435-680-8828").sort().info()
center.calls