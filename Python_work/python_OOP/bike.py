class Bike(object):
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
    def displayInfo(self):
        print "Price: {} \nMax-Speed: {}\nTotal Miles {}".format(self.price, self.max_speed, self.miles)
        return self
    def ride(self):
        print "Riding...."
        self.miles = self.miles + 10
        return self
    def reverse(self):
        print "Reversing...."
        self.miles = self.miles - 5
        if self.miles < 0:
            self.miles = 0
        return self

Bike1 = Bike(200,"25mph")
Bike1.ride().ride().ride().reverse()

Bike2 = Bike(150,"20mph")
Bike2.ride().ride().reverse()

Bike3 = Bike(125,"15mph")
Bike3.reverse().reverse().reverse()


print Bike1.displayInfo()
print Bike2.displayInfo()
print Bike3.displayInfo()


