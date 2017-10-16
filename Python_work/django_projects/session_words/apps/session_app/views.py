from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
from django.db import OperationalError
from models import Word

# Create your views here.
def index(request):
    try:
        context = {
            'Words' : Word.objects.all(),
        }
        return render(request , "session_app/index.html", context)
    except OperationalError:
        return render(request , "session_app/index.html", context)

def add(request):
    if request.method == "POST":
        word = request.POST['word']
        color = request.POST['radio']
        checkbox  = request.POST.get('checkbox', False)
        if checkbox == "True":
            checkbox = True
        else:
            checkbox = False
        print word, color, checkbox
        Word.objects.create(word=word, color=color, bold=checkbox)
        return redirect("/")
    else:
        return redirect("/")

def delete(request):
    if request.method == "POST":
        w = Word.objects.all()
        w.delete()
        return redirect("/")
    else:
        return redirect("/")