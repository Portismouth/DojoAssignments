from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string


# Create your views here.
def index(request):
    return render(request , "survey/index.html")

# Process form
def process(request):
    print "form posted"
    request.session['name'] = request.POST['name']
    request.session['location'] = request.POST['location']
    request.session['language'] = request.POST['language']
    request.session['message'] = request.POST['message']
    return redirect("/result")

#Results page
def result(request):
    return render(request , "survey/result.html")

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