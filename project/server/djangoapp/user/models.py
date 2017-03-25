from django.db import models

# Create your models here.

#[NITIN] Do not create user model. Django has default user table with neccessary functions.
#  we can extend user model.
class User_table(models.Model):
    username_text = models.CharField(max_length=100)
    password_text = models.CharField(max_length=100)
    upload_time = models.DurationField(null='true')        #check parameters
    no_of_upload = models.IntegerField(null='true')
    no_of_tamper = models.IntegerField(null='true')
    client_ip = models.GenericIPAddressField(protocol='both', unpack_ipv4=True, null='true')

    def __str__(self):
        return self.username_text      

#[NITIN] Do not name tables as '_DB' or '_Table'.  
#  add some small comments about purpose of model. It is very confusing to understand what do you mean by 'Original'
class Original_DB(models.Model):
    roll_no = models.IntegerField()
    name = models.CharField(max_length=100)
    centre = models.IntegerField()
    sec1 = models.IntegerField()
    sec2 = models.IntegerField()
    sec3 = models.IntegerField()
    total = models.IntegerField()

# [NITIN] I think AnswersheetScan will be a better model name. Hash value will be just one field of the AnswersheetScan

    def __str__(self):
        return self.roll_no

class Hash_table(models.Model):
    hash_code =  models.CharField(max_length=100)
    img_addr = models.CharField(max_length=100)

    def __str__(self):
        return self.img_addr

    

