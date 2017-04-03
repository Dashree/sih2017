from django.shortcuts import render
from django.http import HttpResponse
from django.contrib.auth.decorators import login_required
from django.views.decorators.http import require_GET, require_POST

from .models import AnswersheetTemplate, ExamInfo

# Create your views here.
@require_GET
def index(request):
    return HttpResponse("Exams app")


@require_GET
def download_rollnumbersect(request, examid):
    exam = ExamInfo.objects.get(id=examid)
    image = exam.templateinfo.rollnumbersect
    filename = "rollnumbersect_%d" %examid
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_centrecodesect(request, examid):
    exam = ExamInfo.objects.get(id=examid)
    image = exam.templateinfo.rollnumbersect
    filename = "centrecodesect_%d" %examid
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_answercolumnsect(request, examid):
    exam = ExamInfo.objects.get(id=examid)
    image = exam.templateinfo.rollnumbersect
    filename = "answercolumnsect_%d" %examid
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

