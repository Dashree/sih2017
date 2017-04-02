from django.contrib import admin

# Register your models here.
from .models import ExamInfo,StudentInfo

admin.site.register(StudentInfo)
admin.site.register(ExamInfo)
