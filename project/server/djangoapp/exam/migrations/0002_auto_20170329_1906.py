# -*- coding: utf-8 -*-
# Generated by Django 1.10.6 on 2017-03-29 13:36
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('exam', '0001_initial'),
    ]

    operations = [
        migrations.RenameModel(
            old_name='Final_marks',
            new_name='AnswerSheetMarks',
        ),
        migrations.RenameModel(
            old_name='Exam_table',
            new_name='ExamInfo',
        ),
    ]
