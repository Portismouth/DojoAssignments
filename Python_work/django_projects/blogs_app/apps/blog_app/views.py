from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "placeholder to later display all the list of blogs"
    return HttpResponse(response)

def new(request):
    response = "placeholder to display a new form to create a new blog"
    return HttpResponse(response)

def create(request):
    return redirect("/")

def show(request, number):
    print number
    response = "placeholder for number:", number
    return HttpResponse(response)

def edit(request, number):
    response = "Place holder for number:",number," edit page"
    return HttpResponse(response)

def destroy(request, number):
    return redirect('/')