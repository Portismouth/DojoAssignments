from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "placeholder to later display all the list of surveys"
    return HttpResponse(response)

def survey(request):
    response = "placeholder for users to make new survey"
    return HttpResponse(response)