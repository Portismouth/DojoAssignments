import random

def coin_toss(n):
    heads = 0
    tails = 0
    for toss in range(1, n+1):
        flip = random.randint(0,1)
        if flip == 0:
            tails += 1
            print "Attempt #"+str(toss)+": Throwing a coin... It's a tail! ... Got",tails,"tail(s) so far and",heads,"head(s) so far"
        else:
            heads += 1
            print "Attempt #"+str(toss)+": Throwing a coin... It's a head! ... Got",tails,"tail(s) so far and",heads,"head(s) so far"
    heads_avg = heads / float(n) * 100
    tails_avg = tails / float(n) * 100   
    print "--------------"
    print "Heads Average:",heads_avg,"percent"
    print "Tails Average:",tails_avg,"percent"
coin_toss(5000)