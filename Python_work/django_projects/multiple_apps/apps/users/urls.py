from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^/login$', views.login),
    url(r'^/register$', views.register),
    url(r'^/new$', views.register),
    url(r'^$', views.index)
]
