def prime_square():
    for i in range (100, 1000):
        prime = True
        perfect_square = False
        # Checks in range from 2 to the number we are at to see if any multiples of it are prime/square
        for j in range(2, i):
            if i % j == 0:
                prime = False
            if j * j == i:
                perfect_square = True
        if prime:
            print "foo"
        if perfect_square:
            print "bar"
        
prime_square()