from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.db.models import Avg, Count
from models import User, Message, Reply
import bcrypt
import re


#------------------------------ Page loading ------------------------------#


def index(request):
    if 'id' in request.session:
        user = User.objects.get(id = request.session['id'])
        context = {
            'User': user,
        }
        return render(request , "users/index.html", context)
    return render(request , "users/index.html")

def dashboard(request):
    all_users = User.objects.all()
    logged = User.objects.get(id = request.session['id'])
    context = {
        'User': logged,
        'all_users': all_users,
    }
    return render(request,"users/show.html", context)

def profile(request, number):
    user = User.objects.get(id = number)
    logged = User.objects.get(id = request.session['id'])
    messages = user.user_messages.all()
    for message in messages:
        print message.content
    context = {
        'Profile': user,
        'User': logged,
        'messages': messages
    }
    return render(request,"users/profile.html", context)

#------------------------------ Edit Profile ------------------------------#

#Edit User user
def edit(request):
    user = User.objects.get(id = request.session['id'])
    if request.method == "POST":
        #Updating description
        if request.POST['hidden'] == 'description':
            description = request.POST['description']
            user.desc = description
            user.save()
            return redirect('/user/edit')

        first_name = request.POST['first_name']
        last_name = request.POST['last_name']
        username = request.POST['username']
        email = request.POST['email'].lower()
        #Validation in models.py AND creates user if no errors
        valid, response = User.objects.edit_validator(request.POST, user)
        if valid:
            user.first_name = first_name
            user.last_name = last_name
            if username != user.username:
                user.username = username
            if email != user.email:
                user.email = email 
            user.save()
            request.session['success'] = "Information updated!"
            return redirect('/user/edit')
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/user/edit')
    else:
        context = {
            'User': user,
        }
        return render(request , "users/edit.html", context)

#Create user
def edit_password(request):
    user = User.objects.get(id = request.session['id'])
    if request.method == "POST":
        #Validation in models.py AND creates user if no errors
        valid, response = User.objects.password_validator(request.POST)
        if valid:
            #Success set hashed pw
            password= request.POST['password']
            hashed = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
            user.password = hashed
            user.save()
            return redirect('/user/edit')
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/user/edit')

def add_description(request):
    user = User.objects.get(id = request.session['id'])
    if request.method == "POST":
        #Validation in models.py AND creates user if no errors
        valid, response = User.objects.password_validator(request.POST)
        if valid:
            #Success set hashed pw
            password= request.POST['password']
            hashed = bcrypt.hashpw(password.encode(), bcrypt.gensalt())
            user.password = hashed
            user.save()
            return redirect('/user/edit')
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/user/edit')

#------------------------------ REGISTER/LOGIN ------------------------------#

#Create user
def register(request):
    if request.method == "POST":
        #Validation in models.py AND creates user if no errors
        valid, response = User.objects.register_validator(request.POST)
        if valid:
            request.session['id'] = response.id
            request.session['success'] = "registered"
            return redirect('/dashboard')
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/login')
    else:
        return redirect('/login')

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
            return redirect("/dashboard")
        else:
            for message in response:
                messages.error(request, message)
            return redirect('/login')
    else:
        if 'id' in request.session:
            user = User.objects.get(id = request.session['id'])
            context = {
                'User': user,
            }
            return render(request , "users/login.html", context)
        return render(request , "users/login.html")
         
def logout(request):
    if request.method == "POST":
        del request.session['id']
        del request.session['success']
        return redirect("/")
    else:
        del request.session['id']
        del request.session['success']
        return redirect("/")

#------------------------------ Messages ------------------------------#
def message(request, number):
    if request.method == "POST":
        profile = User.objects.get(id = number)
        message = request.POST['message']
        commentor = request.POST['user_id']
        Message.objects.create(content= message, commentor=int(commentor), user=User.objects.get(id=number))
        return redirect("/user/profile/"+number)