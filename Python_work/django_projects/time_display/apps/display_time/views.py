from django.shortcuts import render, HttpResponse, redirect
from time import gmtime, strftime, localtime

# Create your views here.
def index(request):
    content = {
        'date' : strftime("%b %d, %Y", gmtime()),
        'time' : strftime("%H:%M %p", gmtime())
    }
    return render(request, "time_display/index.html", content)
