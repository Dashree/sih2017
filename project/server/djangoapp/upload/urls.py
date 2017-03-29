# urls.py of the upload app.

from django.conf.urls import url

from .views import file_list,upload_file

urlpatterns = [
    url(r'^list/$', file_list , name = 'list'),
    url(r'^file/$', upload_file, name= 'fileupload'),
   # url(r'^hash/?P<hashval>)
    ]
