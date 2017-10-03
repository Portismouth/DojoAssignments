
# THIS IS HOW I WOULD DO IT
def find(char, word_list):
    new_list = []
    for i in word_list:
        found = False
        for x in i:
            if x == char:
                found = True
        if found:
            new_list.append(i)
    print new_list

def other(char, word_list):
    new_list = [i for i in word_list if char in i]
    print new_list

word_list = ['hello','world','my','name','is','Anna']
char = 'o'
other(char, word_list)