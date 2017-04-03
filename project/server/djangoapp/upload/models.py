import hashlib

from django.db import models
from exam.models import StudentInfo,ExamInfo
from django.contrib.auth.models import User

# Create your models here.

class ScannedImage(models.Model):
    '''
    represents scanned image uploaded to server.
    '''
    docfile = models.FileField(upload_to='documents/%d')
    hashval = models.CharField(max_length=128, null=False, blank=False,editable=False,db_index=True, unique=True)
    imgsize =  models.IntegerField(editable=False)
    studentid = models.ForeignKey(StudentInfo, null=True, blank=True)
    #session = models.ForeignKey(XGenSession)
    userid = models.ForeignKey(User)
    examid = models.ForeignKey(ExamInfo)

    def clean(self):
        #automatically hashval function based on content of file object
        hasher = hashlib.sha512()
        self.docfile.open("rb")
        hasher.update(self.docfile.read())
        self.hashval = hasher.hexdigest()
        self.hashval = self.hashval.lower()
        self.imgsize = self.docfile.size
