# urls.py of the upload app.

from django.conf.urls import url

from .views import scanned_list,upload_file,check_hash,all_image_list

urlpatterns = [
    url(r'^list/scannedimages/$', scanned_list , name = 'list'),
    #url(r'^list/scannedimages/$', all_image_list , name = 'list'),
    
    #url(r'^list/processedimages/(?P<uid>\w+)/$', processed_list , name = 'processedlist'),
    #url(r'^file/$', upload_file, name= 'fileupload'),
    url(r'^file/(?P<examcode>\w+)/(?P<stdrollno>\w+)/$', upload_file, name= 'fileupload'),
    url(r'^hash/(?P<hashvalue>\w+)/$', check_hash, name='checkhash'),
    #url(r'^image/(?P<imageid>\w+)/$', download_image, name='imagedownload'),
    #url(r'^template/(?P<examid>\w+)/$', download_template, name='templatedownload')
   ]
