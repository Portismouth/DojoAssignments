from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.contrib.auth.models import User
import md5
import re
import os, binascii

# Load home page
def index(request):
    context = {
        'Users': User.objects.all(),
    }
    return render(request , "login_app/index.html", context)


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
        if success:
            password = md5.new(password).hexdigest()
            salt =  binascii.b2a_hex(os.urandom(15))
            hashed_pw = md5.new(password + salt).hexdigest()
            User.objects.create(first_name=first_name, last_name=last_name,email=email, username=username, password=hashed_pw)
            print User.objects.all()
            print "success"
            return redirect('/')
        print first_name
        print "FAIL"
        return redirect('/')
    else:
        return redirect('/')
