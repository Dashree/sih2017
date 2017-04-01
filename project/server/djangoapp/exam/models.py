from django.db import models

# Create your models here.
#This table contains the information regarding the Exam information.
class ExamInfo(models.Model):
    examcode = models.CharField(max_length=100, unique=True)
    exam_name = models.CharField(max_length=100, unique=True)
    modelanstemplate = models.FileField(null= True)     #check for address storing field
    exam_date = models.datefield(null =True)
    templateinfo = models.ForeignKey('AnswersheetTemplate')
    
class AnswersheetTemplate():        #section of templates
    rollnumber = models.FileField(models.Model) 
    centrecode = models.FileField(models.Model)
    answercolumn = models.FileField(models.Model)
    completetemplate = models.FileField(models.Model)
#This table contains the basic and original student information.
class Student_info(models.Model):
    Roll_no = models.CharField(max_length=10, unique=True, null=True)
    student_name = models.CharField(max_length=100)
    #centre_name = models.CharField(max_length=100)
    examid = models.ForeignKey('ExamInfo')

#[This table will hold the marks(Question wise marks) when they come from the workers.]
class AnswerSheetMarks(models.Model):
    examid = models.ForeignKey('ExamInfo')
    studentid = models.ForeignKey('Student_info')
    #check if need of on delete cascade is need or we should use 'protect'.
    sect_no = models.IntegerField()
    ques_no = models.IntegerField()
    mark = models.IntegerField()
    
    
    
