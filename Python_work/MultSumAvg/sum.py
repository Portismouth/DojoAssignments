#FOR LOOP FOR ALL ODD NUMBERS
def odds():
    for i in range(1000):
        if i % 2 == 1:
            print i

#odds()

#Print all multiples of 5 from 5 to 1,000,000
def fives():
    for i in range(5,1000001):
        if i % 5 == 0:
            print i

#fives()

#Sum of all values in a list
def sum_of_numbers():
    a = [1, 2, 5, 10, 255, 3]
    print sum(a)

#sum_of_numbers()


#Avg of all values in a list
def avg():
    a = [1, 2, 5, 10, 255, 3]
    print sum(a)/float(len(a))

avg()