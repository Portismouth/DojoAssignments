from django.conf.urls import url, include
from django.contrib import admin
from . import views

urlpatterns = [
    url(r'^dashboard$', views.dashboard, name="dashboard"),
    url(r'^user/edit$', views.edit, name="edit_profile"),
    url(r'^user/profile/(?P<number>\d+)$', views.profile, name="profile"),
    url(r'^user/edit/password$', views.edit_password, name="edit_password"),
    url(r'^user/profile/(?P<number>\d+)/message$', views.message, name="message"),
    url(r'^logout$', views.logout, name="logout"),
    url(r'^login$', views.login, name="login"),
    url(r'^$', views.index, name="home"),
    url(r'^register$', views.register, name="register")
]