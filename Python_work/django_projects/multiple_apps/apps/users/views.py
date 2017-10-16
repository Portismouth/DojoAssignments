from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "placeholder to later display all the list of users"
    return HttpResponse(response)

def register(request):
    response = "placeholder for register form"
    return HttpResponse(response)

def login(request):
    response = "placeholder for login form"
    return HttpResponse(response)