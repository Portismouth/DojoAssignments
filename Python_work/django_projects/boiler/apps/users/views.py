from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from models import User
import bcrypt
import re

# Load home page
def index(request):
    context = {
        'Users': User.objects.all(),
    }
    return render(request , "users/index.html", context)

# def user_page(request, id):
#     try:
#         user = User.objects.get(id=request.session['id'])
#         context = {
#             'User': user,
#         }
#         return render(request,"users/welcome.html", context)
#     except:
#         messages.error(request, "Something went wrong with your login, please try again")
#         return redirect("/")

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

