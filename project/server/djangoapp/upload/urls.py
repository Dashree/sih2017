# urls.py of the upload app.

from django.conf.urls import url
from upload.views import list

urlpatterns = [
    url(r'^list/$', list , name = 'list')
    ]
