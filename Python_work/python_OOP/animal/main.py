# import animal_class < ----- I cannot get this to work
class Animal(object):
    def __init__(self, name, health):
        self.name = name
        self.health = health
    def walk(self):
        self.health -= 1
        return self
    def run(self):
        self.health -= 5
        return self
    def display_health(self):
        print "The {}'s current health is: {}".format(self.name, self.health)
        return self

class Dog(Animal):
    def __init__(self,name, health):
        super(Dog, self).__init__(name, health)
    def pet(self):
        self.health += 5
        return self
class Dragon(Animal):
    def __init__(self, name, health=170):
        super(Dragon, self).__init__(name, health)
    def fly(self):
        self.health -= 10
        return self
    def display_health(self):
        super(Dragon, self).display_health()
        print "I am a Dragon"
        return self

dog = Dog("Dog", 25)
dog.walk().walk().walk().pet()
dog.display_health()

dragon = Dragon("Dragon")
dragon.fly()
dragon.display_health()