#Find and Replace
s = "It's thanksgiving day. It's my birthday,too!"
print s.find('day')
new = s.replace('day', 'month', 1)
print new

#Max and Min Values
x = [2,54,-2,7,12,98]
minimum = min(x)
maximum = max(x)
print minimum , maximum

#first and last value
y = ["hello",2,54,-2,7,12,98,"world"]
print y[0], y[-1]

#New List
z = [19,2,54,-2,7,12,98,32,10,-3,6]
z.sort()
half = len(z) / 2
new = z[:half]
z[:half] = []
z.insert(0, new)
print z
