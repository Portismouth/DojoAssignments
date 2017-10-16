from django.conf.urls import url, include
from django.contrib import admin
from . import views
urlpatterns = [
    url(r'^process_money$', views.process),
    url(r'^clear$', views.clear),
    url(r'^', views.index),
]
