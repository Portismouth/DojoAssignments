from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from .. users.models import User

# Create your views here.
def index(request):
    print request.session['id']
    user = User.objects.get(id=request.session['id'])
    context = {
        'User': user, 
        'things': "PLACEHOLDER FOR ALL THINGS",
    }
    return render(request , "things/index.html", context)

def new(request):
    return render(request , "things/new.html")

def show(request, number):
    context = {
        'User': User.objects.get(id=number)
    }
    return render(request, "things/show.html", context)

def edit(request, number):
    response = "Place holder for number:",number," edit page"
    return HttpResponse(response)

def destroy(request, number):
    return redirect('/')