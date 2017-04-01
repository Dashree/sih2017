import hashlib

from django.db import models
from exam.models import StudentInfo

# Create your models here.

class ScannedImage(models.Model):
    '''
    represents scanned image uploaded to server.
    '''
    docfile = models.FileField(upload_to='documents/%d')
    hashval = models.CharField(max_length=128, null=True, blank=False,editable=False,db_index=True, unique=True)
    imgsize =  models.IntegerField(editable=False)
    studentid = models.ForeignKey(StudentInfo, null=True)
    #session = models.ForeignKey(XGenSession)

    def clean(self):
        #automatically hashval function based on content of file object
        hasher = hashlib.sha512()
        with self.docfile.open("rb") as f:
            hasher.update(f.read())
        self.hashval = hasher.hexdigest()
        self.imgsize = self.docfile.size
