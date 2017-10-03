def odd():
    for i in range(1,2001):
        if i % 2 == 0:
            print "Number is",i,"This is a even number"
        else:
            print "Number is",i,"This is a odd number"

#odd()

def multiply_list(lst, n):
    #TWO DIFFERENT WAYS TO DO THIS
    
    #for i in range(len(lst)):
        #lst[i] = lst[i] * n
    #return lst

    lst = [i*n for i in lst]
    return lst

a = [2,4,10,16]
b = multiply_list(a, 5)
#print b

def hacker(arr):
    new_array = []
    for i in range(len(arr)):
        one_array = []
        for j in range(arr[i]):
            one_array.append(1)
        new_array.append(one_array)
    return new_array


x = hacker(multiply_list(a, 2))
print x