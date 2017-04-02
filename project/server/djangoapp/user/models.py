from django.db import models
from django.contrib.auth.models import User

# Create your models here.

class OMR_Session(models.Model):
    logintime = models.DateTimeField(auto_now_add=True)
    logouttime = models.DateTimeField(null=True)
    ipaddress = models.GenericIPAddressField(protocol='both', unpack_ipv4=True, null=True)
    user = models.ForeignKey(User, null=False)
    
