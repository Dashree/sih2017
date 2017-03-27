from django.db import models

# Create your models here.
#This table contains the information regarding the Exam information.
class Exam_table(models.Model):
    exam_id = models.CharField(max_length=100)
    exam_name = models.CharField(max_length=100)
    #exam_date = models.datefield(null = 'True')

#This table contains the basic and orignal student information.
class Student_info(models.Model):
    Roll_no = models.CharField(max_length=10)
    student_name = models.CharField(max_length=100)
    centre_name = models.CharField(max_length=100)

#[Akshata this table will hold the marks when they come from the workers.]
class Final_marks(models.Model):
    sect1 = models.IntegerField(null = 'True')
    sect2 = models.IntegerField(null = 'True')
    sect3 = models.IntegerField(null = 'True')
    total = models.IntegerField(null = 'True')
    
    