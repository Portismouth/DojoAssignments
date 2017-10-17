from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "placeholder for Dojo Ninjas"
    return HttpResponse(response)