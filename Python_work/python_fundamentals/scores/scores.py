import random

def scores():
    for i in range(11):
        random_num = random.randrange(60,101)
        if random_num <= 100 and random_num >= 90:
            print "Score: "+str(random_num)+"; Your grade is A"
        elif random_num <= 89 and random_num >= 80:
            print "Score: "+str(random_num)+"; Your grade is B"
        elif random_num <= 79 and random_num >= 70:
            print "Score: "+str(random_num)+"; Your grade is C"
        elif random_num <= 69 and random_num >= 60:
            print "Score: "+str(random_num)+"; Your grade is D"

scores()
