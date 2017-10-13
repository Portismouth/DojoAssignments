from django.shortcuts import render

# Create your views here.
def index(request):
    print "WE MADE IT"
    return render(request,"index.html")