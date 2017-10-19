from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.db.models import Avg, Count
from models import User
import bcrypt
import re

# Load home page
def index(request):
    context = {
        'Users': User.objects.all(),
    }
    return render(request , "users/index.html", context)

def show(request, number):
    user = User.objects.get(id=number)
    logged = User.objects.get(id = request.session['id'])
    user_reviews = user.user_reviews.annotate(count = Count('id'))
    context = {
        'User': user,
        'logged_user': logged,
        'Reviews': user_reviews,
    }
    return render(request,"users/show.html", context)

#Create user
def register(request):
    if request.method == "POST":
        #Validation in models.py AND creates user if no errors
        valid, response = User.objects.register_validator(request.POST)
        if valid:
            request.session['id'] = response.id
            request.session['success'] = "registered"
            return redirect('/books')
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/')
    else:
        return redirect('/')

def login(request):
    if request.method == "POST":
        #Validation in models.py
        valid, response = User.objects.login_validator(request.POST)
        username = request.POST['username']
        password = request.POST['password']
        if valid:
            print response.id
            request.session['id'] = response.id
            request.session['success'] = "logged in"
            return redirect("/books")
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/')
    else:
        if  "username" in request.session:
            return redirect('/welcome')
        else:
            return redirect('/')
         
def logout(request):
    if request.method == "POST":
        del request.session['id']
        del request.session['success']
        return redirect("/")
    else:
        del request.session['id']
        del request.session['success']
        return redirect("/")

