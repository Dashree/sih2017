from django.db import models
from django.contrib.auth import User

# Create your models here.

class OMR_Session(models.Model):
    logintime = models.DateTimeField()
    logouttime = models.DateTimeField()
    ipaddress = models.IPAddressField(protocol='both', unpack_ipv4=True)
    user = models.ForeignKey(models.Model)
    
