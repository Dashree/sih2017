from django.db import models

# Create your models here.

class User_table(models.Model):
    username_text = models.CharField(max_length=100)
    password_text = models.CharField(max_length=100)
    upload_time = models.DurationField()        #check parameters
    no_of_upload = models.IntegerField()
    no_of_tamper = models.IntegerField()
    client_ip = models.GenericIPAddressField(protocol='both', unpack_ipv4=True)


class Original_DB(models.Model):
    roll_no = models.IntegerField()
    name = models.CharField(max_length=100)
    centre = models.IntegerField()
    sec1 = models.IntegerField()
    sec2 = models.IntegerField()
    sec3 = models.IntegerField()
    total = models.IntegerField()

class Hash_table(models.Model):
    hash_code =  models.CharField(max_length=100)
    img_addr = models.CharField(max_length=100)

