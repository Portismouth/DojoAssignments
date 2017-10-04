class Store(object):
    def __init__(self, products, location, owner):
        self.products = products
        self.location = location
        self.owner = owner
    def add_product(self, product):
        self.products.append(product)
        return self
    def remove_product(self, remove):
        self.products.remove(remove)
        return self
    def inventory(self):
        print "Currently in the store we have:"
        for product in self.products:
            print product
        return self

lst = ["apples", "bananas", "mangos"]
inventory = Store(lst, "Chicago", "Mitchell")
inventory.add_product("Chocolate").inventory().remove_product("apples").inventory()