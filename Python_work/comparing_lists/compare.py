def type_list(val):
    if all(isinstance(x, int) for x in val):
        print "This is a list of integers"
        print sum(val)
    elif all(isinstance(x, str) for x in val):
        print "This is a list of strings"
        print ' '.join(val)
    else:
        print "This is a mixed list"
        num = 0
        string = ''
        for x in val:
            if type(x) == int:
                num += x
            else:
                string += x + ' '
        print 'Sum:', num
        print 'String:', string

        



l1 = ['magical unicorns',19,'hello',98.98,'world']
l2 = [2,3,1,7,4,12]
l3 = [1,2,"hello",3,4,"world",5,6,"coding",7,8,"dojo"]
l4 = ["HELLO", "WORLD"]
type_list(l3)