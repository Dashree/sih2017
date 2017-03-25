from django.conf.urls import url
from . import views

app_name = 'user'


urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^register/$', views.RegisterUserView.as_view(), name='register'),
    url(r'^login/$', views.login_user, name='login')
    
    
]
