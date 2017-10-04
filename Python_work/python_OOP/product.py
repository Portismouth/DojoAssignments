class Product(object):
    def __init__ (self, price, name, weight, brand, status="for sale"):
        self.price = price
        self.name = name
        self.weight = weight
        self.brand = brand
        self.status = status
    def sell(self):
        self.status = "sold"
        return self
    def tax(self, number):
        self.price *= number
        return self
    def return_item(self, reason):
        if "defective" in reason:
            self.status = "defective"
            self.price = 0
        if "in box" in reason:
            self.status = "for sale"
        if "opened" in reason:
            self.status = "used"
            self.price = price * 0.20
        return self
    def display_info(self):
        print "Price: {}\nName: {}\nWeight: {}\nBrand: {}\nStatus: {}".format(self.price, self.name, self.weight, self.brand, self.status)
        return self

tv = Product(500, "Wide Screen", 10, "Samsung")
tv.return_item("This is defective").display_info()