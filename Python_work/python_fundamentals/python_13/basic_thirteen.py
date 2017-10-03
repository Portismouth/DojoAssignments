#1
def one_to_255():
    for num in range(1,256):
        print num

#one_to_255()

#2
def odds():
    for num in range(1,256):
        if num % 2 == 1:
            print num
#odds()

#3
def sum_list():
    sum = 0
    for num in range(0, 256):
        sum += num
        print num , sum
#sum_list()

#4
def array(arr):
    for item in arr:
        print item
arr = [1,2,3,4,5,6]
#array(arr)

#5
def max_list(arr):
    print max(arr)

lst = [7,8,9,22,3,4,5]
#max_list(lst)

#6
def average(arr):
    print arr
    avg = sum(arr) / float(len(arr))
    print avg

#average(lst)

#7
def return_odds(arr):
    new_lst = []
    for item in arr:
        if item % 2 == 1:
            new_lst.append(item)
    print new_lst

#return_odds(lst)
#8
def square(arr):
    for item in range(len(arr)):
        arr[item] = arr[item] * arr[item]
    print arr
#square(lst)

#9
def greater_than(arr, y):
    count = 0
    for item in arr:
        if item > y:
            count+=1
    print count

y = 5
#greater_than(lst,y)

#10
def negative(arr):
    for item in range(len(arr)):
        if arr[item] < 0:
            arr[item] = 0
    print arr
lst2 = [-2,-3,-5,8,9,10]
#negative(lst2)

#11
def max_min_avg(arr):
    print max(arr)
    print min(arr)
    print sum(arr) / float(len(arr))

#max_min_avg(lst)

#12
def shift_list(arr):
    print arr[1:] + arr[:1]

#shift_list(lst)

#13
def swap(arr):
    for item in range(len(arr)):
        if arr[item] < 0:
            arr[item] = "dojo"
    print arr
swap(lst2)