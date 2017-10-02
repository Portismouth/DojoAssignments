def checkerboard():
    for i in range(10):
        if i % 2 == 0:
            for x in range(10):
                print "* ",
        else:
            for z in range(10):
                print " "+"*",
        print '\n'
checkerboard()


def cheater():
    row1 = "x x x x x x x "
    row2 = " x x x x x x x"
    for i in range(8):
        if i % 2 == 0:
            print row1
        else: 
            print row2
cheater()