from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^$', views.index, name="home"),
    url(r'^new$', views.new, name="new"),
    url(r'^add/(?P<number>\d+)$', views.add, name="add"),
    url(r'^(?P<number>\d+)$', views.show, name="show"),
    url(r'^(?P<number>\d+)/edit$', views.edit, name="edit"),
    url(r'^(?P<number>\d+)/delete$', views.destroy, name="delete"),
    url(r'^(?P<number>\d+)/delete/review$', views.destroy_review, name="delete_review")
]