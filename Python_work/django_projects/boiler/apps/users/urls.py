from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^logout$', views.logout, name="logout"),
    url(r'^login$', views.login),
    url(r'^welcome$', views.welcome, name="user_page"),
    url(r'^$', views.index, name="login"),
    url(r'^register$', views.register)
]
