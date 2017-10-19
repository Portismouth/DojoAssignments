from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from django.db.models import Avg
from .. users.models import User
from models import *

# Create your views here.
def index(request):
    user = User.objects.get(id=request.session['id'])

    #ANNOTATE AND AGGREGATE TO MIX AVG VALUE OF RATINGS TO DIFFERENT TABLES
    user_books = user.books.annotate(avg = Avg('book_ratings__number'))
    books = Book.objects.annotate(avg = Avg('book_ratings__number'))

    #Saving review ID's of logged in user to check if user has already reviewed
    lst=[]
    reviews = user.user_reviews.all()
    for review in reviews:
        lst.append(review.book.id)


    # Check if book is not already in Use's inventory to show below
    book_list = []
    for book in books:
        if book not in user_books:
            book_list.append(book)

    context = {
        'User': user, 
        'Books': book_list,
        'user_books': user_books,
        'reviews': lst
    }
    return render(request , "books/index.html", context)

def new(request):
    if request.method == "POST":
        user = User.objects.get(id=request.session['id'])
        #Create the new book if it already doesnt exist
        name = request.POST['name']
        author = request.POST['book_author']
        review = request.POST['review']
        rating = int(request.POST['rating'])
        Book.objects.create(name=name, author= author)
        book = Book.objects.get(name = name)
        user.books.add(book)
        user.save()

        #Add ratings and reviews to be accessed by current user
        Review.objects.create(desc=review, book=Book.objects.get(name=name), user = user)

        #Add ratings and reviews to book
        Rating.objects.create(number=rating, book=Book.objects.get(name=name), user = user)

        return redirect('/books')
    else:
        user = User.objects.get(id=request.session['id'])
        context = {
            'User': user, 
        }
        return render(request , "books/new.html", context)

def add(request, number):
    user = User.objects.get(id=request.session['id'])
    book = Book.objects.get(id = number)
    user.books.add(book)
    user.save()
    
    for b in user.books.all():
        print b.name
    return redirect('/books')

def show(request, number):
    book = Book.objects.get(id=number)
    user = User.objects.get(id=request.session['id'])
    ratings = Rating.objects.filter(id = book.id)
    context = {
        'Book': book,
        'Reviews': book.book_reviews.all(),
        'User': user,
        'Ratings': book.book_ratings.all()
    }
    return render(request, "books/show.html", context)

def edit(request, number):
    if request.method == "POST":
        user = User.objects.get(id=request.session['id'])
        #Review fields
        review = request.POST['review']
        rating = int(request.POST['rating'])

        current_book = Book.objects.get(id = number )
        #Add ratings and reviews to be accessed by current user

        #Create Review
        Review.objects.create(desc = review, book = current_book, user= user)

        #Add ratings and reviews to book
        current_book.book_ratings.create(number = rating, book = current_book, user = user)

        return redirect('/books')
    else:
        user = User.objects.get(id=request.session['id'])
        book = Book.objects.get(id = number)
        context = {
            'User': user, 
            'Book': book,
        }
        return render(request , "books/edit.html", context)

def destroy(request, number):
    user = User.objects.get(id =request.session['id'])
    book = Book.objects.get(id = number)
    book.user.remove(user)
    book.save()
    
    return redirect('/books')

def destroy_review(request, number):
    review = Review.objects.get(id=number)
    review.delete()
    return redirect('/books')