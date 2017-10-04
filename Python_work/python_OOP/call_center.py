class Call(object):
    counter = 0
    def __init__(self, name, number, time, reason):
        self.name = name
        self.number = number
        self.time = time
        self.reason = reason
        self.id_number = Call.counter
        Call.counter += 1
    def display(self):
        print "ID: {}\nName: {}\nNumber: {}\nTime: {}\nReason: {}\n".format(self.id_number, self.name, self.number, self.time, self.reason)
        return self

class CallCenter(object):
    def __init__(self):
        self.calls = []
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
        print len(self.calls)
        return self

call1 = Call("Mitchell","435-680-8818","1:51","help")
call2 = Call("Myles","435-680-8828","2:51","hi")
call3 = Call("John","435-680-8838","3:51","hi")
call4 = Call("Jane","435-680-8848","4:51","help")
call5 = Call("Diana","435-680-8858","5:51","hi")

center = CallCenter()
center.add(call1).add(call3).remove().add(call2).remove_number("435-680-8828").sort().info()
center.calls