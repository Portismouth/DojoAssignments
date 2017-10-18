from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^logout$', views.logout),
    url(r'^login$', views.login),
    url(r'^success$', views.success),
    url(r'^$', views.index),
    url(r'^register$', views.register)
]