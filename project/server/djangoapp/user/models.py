from django.db import models

# Create your models here.


# [NITIN] I think AnswersheetScan will be a better model name. Hash value will be just one field of the AnswersheetScan

   
class Hash_table(models.Model):
    hash_code =  models.CharField(max_length=100)
    img_addr = models.CharField(max_length=100)

    def __str__(self):
        return self.img_addr

    

