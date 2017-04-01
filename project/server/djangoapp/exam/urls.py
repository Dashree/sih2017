from django.conf.urls import url
from .views import download_rollnumbersect, download_centrecodesect, download_answercolumnsect


from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^(?P<examid>\w+)/template/rollnosect$', download_rollnumbersect, name='download_rollnumbersect'),
    url(r'^(?P<examid>\w+)/template/centrecodesect$', download_centrecodesect, name='centrecodedownload'),
    url(r'^(?P<examid>\w+)/template/answercolumnsect$', download_answercolumnsect, name='answercolumndownload'),
    #url(r'^(?P<examid>\w+)/template/completetemplate$', download_completetemplate, name='completetemplatedownload'),
]