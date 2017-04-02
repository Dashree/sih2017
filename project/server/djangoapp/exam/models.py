from django.db import models

# Create your models here.
#This table contains the information regarding the Exam information.
    
class AnswersheetTemplate(models.Model):        #section of templates
    rollnumbersect = models.FileField(models.Model) 
    centrecodesect = models.FileField(models.Model)
    answercolumnsect = models.FileField(models.Model)
    completetemplate = models.FileField(models.Model)
    rollx = models.IntegerField(models.Model, default=0)
    rolly = models.IntegerField(models.Model, default=0)
    centrex = models.IntegerField(models.Model,default=0)
    centrey = models.IntegerField(models.Model,default=0)
    answercolumnx = models.IntegerField(models.Model,default=0)
    answercolumny = models.IntegerField(models.Model,default=0)

class ExamInfo(models.Model):
    examcode = models.CharField(max_length=100, unique=True)
    exam_name = models.CharField(max_length=100, unique=True)
    modelanstemplate = models.FileField(upload_to = 'examdocs', null= True)     #check for address storing field
    exam_date = models.DateField(null =True)
    #mastertemplate = models.FileField(upload_to = 'media', null = True)

#This table contains the basic and original student information.
class StudentInfo(models.Model):
    rollno = models.CharField(max_length=10, unique=True, null=True)
    student_name = models.CharField(max_length=100, default='student')
    examid = models.ForeignKey(ExamInfo, null=True)

#[This table will hold the marks(Question wise marks) when they come from the workers.]
class AnswerSheetMarks(models.Model):
    examid = models.ForeignKey(ExamInfo)
    studentid = models.ForeignKey(StudentInfo)
    #check if need of on delete cascade is need or we should use 'protect'.
    sect_no = models.IntegerField()
    ques_no = models.IntegerField()
    mark = models.IntegerField()
    
