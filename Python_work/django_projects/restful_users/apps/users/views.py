from django.contrib import messages
from django.shortcuts import render, HttpResponse, redirect
from models import *
import re

# Load home page
def index(request):
    context = {
        'Users': User.objects.all(),
    }
    return render(request , "users/index.html", context)


#Create user
def register(request):
    if request.method == "POST":
        first_name = request.POST['first_name']
        last_name = request.POST['last_name']
        email = request.POST['email'].lower()
        match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
        success = True
        if len(email) < 1 or len(first_name) < 1 or len(last_name) < 1:
            messages.error(request, 'Please fill out all fields')
            success = False
        if any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
            messages.error(request, 'No numbers in name fields')
            success = False
        if match == None:
            messages.error(request, 'Email is not valid!')
            success = False
        if success:
            User.objects.create(first_name=first_name, last_name=last_name,email=email)
            return redirect('/')
        return redirect('/')
    else:
        return render(request, "users/new.html")

def show(request, id):
    context = {
        'User': User.objects.get(id=id)
    }
    return render(request, "users/show.html", context)

def edit(request, id):
    if request.method == "POST":
        print "is it posting?"
        first_name = request.POST['first_name']
        last_name = request.POST['last_name']
        email = request.POST['email'].lower()
        match = re.match('^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$', email)
        success = True
        if len(email) < 1 or len(first_name) < 1 or len(last_name) < 1:
            messages.error(request, 'Please fill out all fields')
            success = False
        if any(char.isdigit() for char in first_name) or any(char.isdigit() for char in last_name):
            messages.error(request, 'No numbers in name fields')
            success = False
        if match == None:
            messages.error(request, 'Email is not valid!')
            success = False
        if success:
            user = User.objects.get(id=id)
            user.first_name = first_name
            user.last_name = last_name
            user.email = email
            print user.first_name
            user.save()
            return redirect('/')
        else:
            print "elsestatement hitting"
            return redirect('user/'+id+'/edit')
    else:
        context = {
            'User': User.objects.get(id=id)
        }
        return render(request, "users/edit.html", context)

def delete(request, id):
    user = User.objects.get(id=id)
    user.delete()
    return redirect("/") 