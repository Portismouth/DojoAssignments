def compare(list1, list2):
    for i, x in map(None,list1, list2):
        if i == x:
            same = True
        else:
            same = False
    if same:
        print "The Lists are the same"
    else:
        print "The lists are different"


list_one = ['celery','carrots','bread','milk', ]
list_two = ['celery','carrots','bread','cream']
compare(list_one,list_two)