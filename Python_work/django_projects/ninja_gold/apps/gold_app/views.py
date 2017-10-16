from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.db import OperationalError
from django.contrib import messages
import random

# Create your views here.
def index(request):
    if 'gold' not in request.session:
        request.session['gold'] = 0
    if 'action' not in request.session:
        request.session['action'] = []
    return render(request , "gold_app/index.html")

def process(request):
    if request.method =="POST":
        if request.POST['hidden'] == 'farm':
            found = random.randrange(10,21)
            request.session['action'].append("Ninja gained "+str(found)+" gold at the farm")
            request.session['gold'] += found
            return redirect('/')
        if request.POST['hidden'] == 'cave':
            found = random.randrange(5,11)
            request.session['action'].append("Ninja gained "+str(found)+" gold at the cave")
            request.session['gold'] += found
        if request.POST['hidden'] == 'house':
            found = random.randrange(2,6)
            request.session['action'].append("Ninja gained "+str(found)+" gold at the house")
            request.session['gold'] += found
        if request.POST['hidden'] == 'casino':
            check_win = random.randint(0, 1)
            if check_win == 1:
                found = random.randrange(1,51)
                request.session['gold'] += found
                request.session['action'].append("The ninja gained "+str(found)+" gold at the casino")
            else:
                found = random.randrange(1,51)
                request.session['gold'] -= found
                request.session['action'].append("The ninja lost "+str(found)+" gold at the casino")
        return redirect('/')

    return redirect('/')

def clear(request):
    if request.method == "POST":
        del request.session['gold']
        del request.session['action']
        return redirect ('/')
    else:
        return redirect ('/')