from django.shortcuts import render
from .models import ScannedImage
from exam.models import AnswerSheetMarks, ExamInfo, StudentInfo
from django.template import RequestContext
from django.http import HttpResponse, HttpResponseRedirect,HttpResponseNotFound,JsonResponse
from django.core.urlresolvers import reverse

from django.views.decorators.http import require_GET, require_POST
from django.contrib.auth.decorators import login_required
from exam.models import ExamInfo, StudentInfo
from .models import ScannedImage
from .forms import DocumentForm
from exam import models 
from user.models import OMR_Session
from worker import detect, worker_test

@require_GET
@login_required
def all_image_list(request):
    form = DocumentForm()  # A empty, unbound form
    documents = ScannedImage.objects.all()
    #assert len(documents) > 0
    # Render list page with the documents and the form
    return render(
       request,
        'list.html',
        {'documents': documents, 'form': form}
    )

@require_GET
@login_required
def scanned_list(request):
    '''
    show list of uploaded file.
    '''
    # Load documents for the list page
    cursesion = OMR_Session.objects.get(id=request.session['omrsession'])
    documents = ScannedImage.objects.filter(session__user=cursesion.user)
    #assert len(documents) > 0
    # Render list page with the documents and the form
    return render(
       request,
        'list.html',
        {'documents': documents}
    )

@require_POST
@login_required
def upload_file(request,examcode,stdrollno):
    '''
    upload single file
    '''
    #exam = ExamInfo.objects.get(examcode = exmid)
    student, created = StudentInfo.objects.get_or_create(rollno = stdrollno)
    
    if 'file' in request.FILES:
        session = OMR_Session.objects.get(id=request.session['omrsession'])
        scannedimage = ScannedImage(docfile=request.FILES['file'], session=session)
        scannedimage.full_clean()
        scannedimage.save()

        worker_enable = True
        if worker_enable == True:
            
            host = "http://"+request.get_host()
            #exam = ExamInfo.objects.get(examcode = examcode)
            examid = 2
            detect(host, examid,student.id, scannedimage.id)
            #worker_test(host, examid)
        
        response = { 'name' : scannedimage.docfile.name, }
        # Redirect to the document list after POST
        return JsonResponse(response)
    else:
        return HttpResponseNotFound("Unable to upload file")

@require_GET
@login_required
def check_hash(request, hashvalue):
    '''
    check if hash is present or not
    '''
    res = { 'found' : False }
    hashvalue = hashvalue.lower()
    if ScannedImage.objects.filter(hashval = hashvalue).exists():
        res['found'] = True 
        return JsonResponse(res)
    else:
        return JsonResponse(res)
    

@require_GET
def download_scannedimage(request, imageid):
    image = ScannedImage.objects.get(id=imageid)    
    filename = "scannedanswer_%s" %imageid
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_rollnumbersect(request, examcode):
    exam = ExamInfo.objects.get(id=examcode)
    image = exam.templateinfo.rollnumbersect
    filename = "rollnumbersect_%s" %examcode
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_centrecodesect(request, examcode):
    exam = ExamInfo.objects.get(id=examcode)
    image = exam.templateinfo.centrecodesect
    filename = "centrecodesect_%s" %examcode
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_answercolumnsect(request, examcode):
    exam = ExamInfo.objects.get(id=examcode)
    image = exam.templateinfo.answercolumnsect
    filename = "answercolumnsect_%s" %examcode
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename
    
    return response

@require_GET
def download_completetemplate(request, examcode):
    exam = ExamInfo.objects.get(id=examcode)
    image = exam.templateinfo.answercolumnsect
    filename = "completetemplate_%s" %examcode
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename
    
    return response
