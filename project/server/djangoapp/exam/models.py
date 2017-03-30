from django.db import models

# Create your models here.
#This table contains the information regarding the Exam information.
class ExamInfo(models.Model):
    examid = models.CharField(max_length=100)
    exam_name = models.CharField(max_length=100)
    template = models.CharField(max_length=250, null= True)     #check for address storing field
    #exam_date = models.datefield(null = 'True')

#This table contains the basic and original student information.
class Student_info(models.Model):
    Roll_no = models.CharField(max_length=10)
    student_name = models.CharField(max_length=100)
    centre_name = models.CharField(max_length=100)

#[This table will hold the marks(Question wise marks) when they come from the workers.]
class AnswerSheetMarks(models.Model):
    examid = models.ForeignKey('ExamInfo', on_delete=models.CASCADE)
    studentid = models.ForeignKey('Student_info', on_delete=models.CASCADE)
    #check if need of on delete cascade is need or we should use 'protect'.
    sect_no = models.IntegerField()
    ques_no = models.IntegerField()
    mark = models.IntegerField()
    
    
    
