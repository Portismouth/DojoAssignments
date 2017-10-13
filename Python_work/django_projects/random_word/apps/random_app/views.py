from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string


# Create your views here.
def index(request):
    if request.method == 'POST':
        unique_id = get_random_string(length=16)
        request.session['word'] = unique_id
        request.session['count'] += 1
        return redirect("/") 
    if not 'count' in request.session:
        request.session['count'] = 1   
    return render(request , "random_app/index.html")

#reset sessions
def reset(request):
    if request.method == 'POST':
        del request.session['count']
        request.session['word'] = ""
        return redirect("/")
    else:
        del request.session['count']
        request.session['word'] = ""
        return redirect("/")