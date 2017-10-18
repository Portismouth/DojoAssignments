from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.contrib.auth.models import User
import bcrypt
import re

# Load home page
def index(request):
    context = {
        'Users': User.objects.all(),
    }
    return render(request , "login_app/index.html", context)

def success(request):
    try:
        user = User.objects.get(username=request.session['username'])
        context = {
            'User': user,
        }
        return render(request,"login_app/success.html", context)
    except:
        messages.error(request, "Something went wrong with your login, please try again")
        return redirect("/")

#Create user
def register(request):
    if request.method == "POST":
        first_name = request.POST['first_name']
        last_name = request.POST['last_name']
        username = request.POST['username']
        email = request.POST['email'].lower()
        match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
        password = request.POST['password']
        confirm = request.POST['confirm-password']
        u_check = User.objects.filter(username=username)
        e_check = User.objects.filter(email=email)
        success = True
        if len(email) < 1 or len(first_name) < 1 or len(last_name) < 1 or len(password) < 1 or len(confirm) < 1:
            messages.error(request, 'Please fill out all fields')
            success = False
        if any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
            messages.error(request, 'No numbers in name fields')
            success = False
        if len(password) < 8 or len(confirm) < 8:
            messages.error(request, 'Password needs to be more than 8 characters')
            success = False
        if password != confirm:
            messages.error(request, 'Passwords need to match')
            success = False
        if match == None:
            messages.error(request, 'Email is not valid!')
            success = False
        if len(u_check) > 0:
            messages.error(request, 'Username already taken')
            success = False
        if len(e_check) > 0:
            messages.error(request, 'email already taken')
            success = False
        if success:
            hashed = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
            User.objects.create(first_name=first_name, last_name=last_name,email=email, username=username, password=hashed)
            user = User.objects.get(email=email)
            request.session['username'] = user.username
            request.session['success'] = "registered"
            return redirect('/success')
        return redirect('/')
    else:
        return redirect('/')

def login(request):
    if request.method == "POST":
        username = request.POST['username']
        password = request.POST['password']
        user = User.objects.get(username=username)
        stored_hashed = user.password
        success=True
        if len(User.objects.filter(username = username)) < 1:
            messages.error(request, 'Incorrect Username')
            success = False
        if not bcrypt.checkpw(password.encode('utf-8'), stored_hashed.encode('utf-8')):
            messages.error(request, 'Incorrect Password')
            success = False
        if success:
            request.session['username'] = user.username
            request.session['success'] = "logged in"
            return redirect("/success")
        return redirect('/')
    else:
        if  "username" in request.session:
            return redirect('/success')
        else:
            return redirect('/')
         
def logout(request):
    if request.method == "POST":
        del request.session['username']
        del request.session['success']
        return redirect("/")
    else:
        del request.session['username']
        del request.session['success']
        return redirect("/")

