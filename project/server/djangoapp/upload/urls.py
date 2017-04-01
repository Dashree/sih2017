# urls.py of the upload app.

from django.conf.urls import url

from .views import file_list,upload_file,check_hash,download_template

urlpatterns = [
    url(r'^list/$', file_list , name = 'list'),
    url(r'^file/$', upload_file, name= 'fileupload'),
    url(r'^hash/(?P<hashvalue>\w+)/$', check_hash, name='checkhash'),
    #url(r'^image/(?P<imageid>\w+)/$', download_image, name='imagedownload'),
    url(r'^template/(?P<examid>\w+)/$', download_template, name='templatedownload')
   ]
