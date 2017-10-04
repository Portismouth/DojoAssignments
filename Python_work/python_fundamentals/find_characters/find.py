
# THIS IS HOW I WOULD DO IT
def find(char, word_list):
    new_list = []
    for word in word_list:
        found = False
        for character in word:
            if character == char:
                found = True
        if found:
            new_list.append(word)
    #print new_list

def other(char, word_list):
    new_list = [word for word in word_list if char in word]
    print new_list

word_list = ['hello','world','my','name','is','Anna']
char = 'o'
other(char, word_list)