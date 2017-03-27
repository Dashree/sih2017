import hashlib

from django.db import models

# Create your models here.

class ScannedImage(models.Model):
    '''
    represents scanned image uploaded to server.
    '''
    docfile = models.FileField(upload_to='documents/%d')
    hashval = models.CharField(max_length=128, null=False, blank=False,editable=False,db_index=True)
    #session = models.ForeignKey(XGenSession)

    def clean(self):
        #automatically hashval function based on content of file object
        hasher = hashlib.sha512()
        with self.docfile.open("rb") as f:
            hasher.update(f.read())
        self.hashval = hasher.hexdigest()

