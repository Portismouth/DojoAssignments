from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^user/(?P<id>\d+)/edit$', views.edit),
    url(r'^user/(?P<id>\d+$)', views.show),
    url(r'^delete/(?P<id>\d+$)', views.delete),
    url(r'^register$', views.register),
    url(r'^new$', views.register),
    url(r'^$', views.index)
]
