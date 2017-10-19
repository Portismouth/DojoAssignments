from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^$', views.index, name="home"),
    url(r'^new/$', views.new, name="new"),
    url(r'^(?P<number>\d+)/$', views.show, name="show"),
    url(r'^(?P<number>\d+)/edit$', views.edit, name="edit"),
    url(r'^(?P<number>[0-9]{2})/delete$', views.destroy)
]