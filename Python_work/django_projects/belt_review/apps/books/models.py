from __future__ import unicode_literals
from django.db import models
from .. users.models import User
import re
import bcrypt

# Create your models here.
class Book(models.Model):
    name = models.CharField(max_length=255)
    author = models.CharField(max_length=255)
    user = models.ManyToManyField(User, blank="True", related_name="books")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Review(models.Model):
    desc = models.CharField(max_length=255)
    book = models.ForeignKey(Book, related_name="book_reviews")
    user = models.ForeignKey(User, related_name="user_reviews")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

class Rating(models.Model):
    number = models.IntegerField()
    book = models.ForeignKey(Book, related_name="book_ratings")
    user = models.ForeignKey(User, related_name="user_ratings")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    

