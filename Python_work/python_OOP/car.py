class Car(object):
    def __init__(self, price, speed, fuel, mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if price > 10000:
            self.tax = 0.15
        else: 
            self.tax = 0.12
    def displayAll(self):
        print "Price: {}\nSpeed: {}\nFuel: {}\nMileage: {}\nTax: {}\n".format(self.price, self.speed, self.fuel, self.mileage, self.tax)


Car1 = Car(2000, "100mph", "Full", "17mpg") 
Car1.displayAll()

Car2 = Car(3500, "115mph", "Full", "23mpg")
Car2.displayAll()

Car3 = Car(9000, "90mph", "Half Full", "15mpg")
Car3.displayAll()

Car4 = Car(12000, "130mph", "Half Full", "32mpg")
Car4.displayAll()

Car5 = Car(7000, "80mph", "Full", "19mpg")
Car5.displayAll()

Car6 = Car(35000, "1140mph", "Half Full", "27mpg")
Car6.displayAll()