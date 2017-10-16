from django.conf.urls import url, include
from django.contrib import admin
from . import views


urlpatterns = [
    url(r'process$', views.add),
    url(r'clear$', views.delete),
    url(r'$', views.index)
]
