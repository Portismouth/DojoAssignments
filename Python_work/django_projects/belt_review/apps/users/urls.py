from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^user/(?P<number>\d+)$', views.show, name="show"),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^login$', views.login),
    url(r'^$', views.index, name="login"),
    url(r'^register$', views.register)
]
