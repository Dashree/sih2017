import hashlib

from django.db import models
from django.contrib.auth.models import User

from user.models import OMR_Session
from exam.models import StudentInfo,ExamInfo

PROCESSED_CHOICES = (
    ('U', 'Unprocessed'),
    ('E', 'Processed with Error'),
    ('P', 'Processed Success')
)
# Create your models here.

class ScannedImage(models.Model):
    '''
    represents scanned image uploaded to server.
    '''
    docfile = models.FileField(upload_to='documents/%d')
    hashval = models.CharField(max_length=128, null=False, blank=False,editable=False,db_index=True, unique=True)
    imgsize =  models.IntegerField(editable=False)
    studentid = models.ForeignKey(StudentInfo, null=True, blank=True)
    session = models.ForeignKey(OMR_Session, null=True, editable=False,blank=True)
    examid = models.ForeignKey(ExamInfo,null=True, blank=True)
    processed = models.CharField(max_length=1, choices = PROCESSED_CHOICES, default='U')

    def clean(self):
        #automatically hashval function based on content of file object
        hasher = hashlib.sha512()
        self.docfile.open("rb")
        hasher.update(self.docfile.read())
        self.hashval = hasher.hexdigest()
        self.hashval = self.hashval.lower()
        self.imgsize = self.docfile.size
        