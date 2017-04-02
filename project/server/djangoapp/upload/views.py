from django.shortcuts import render
from .models import ScannedImage

from django.template import RequestContext
from django.http import HttpResponseRedirect,HttpResponseNotFound,JsonResponse
from django.core.urlresolvers import reverse

from django.views.decorators.http import require_GET, require_POST
from django.contrib.auth.decorators import login_required
from exam.models import ExamInfo
from .models import ScannedImage
from .forms import DocumentForm
from exam import models 


@require_GET
@login_required
def scanned_list(request, uid):
    '''
    show list of uploaded file.
    '''
    # Load documents for the list page
    documents = ScannedImage.objects.filter(userid = uid)
    #assert len(documents) > 0
    # Render list page with the documents and the form
    return render(
       request,
        'list.html',
        {'documents': documents}
    )

@require_POST
@login_required
def upload_file(request,exmid,stdid):
    '''
    upload single file
    '''
    exam = ExamInfo.objects.get(id = exmid)
    student = StudentInfo.objects.get(id = stdid)
    
    if 'file' in request.FILES:
        scannedimage = ScannedImage(docfile=request.FILES['file'],examid = exam,studentid = student)
        scannedimage.full_clean()
        scannedimage.save()

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
def download_template(request, examid):
    template=ExamInfo.objects.filter(id=examid)
    filename = "downloadedtemplate_%d" %examid
    response = HttpResponse(template.docfile, content_type='image/jpeg')
         #examid is passed by the url and equivalent to the default id of ExamInfo table
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

@require_GET
def download_scannedimage(request, imageid):
    image = ScannedImage.objects.get(id=imageid)    
    filename = "scannedanswer_%d" %imageid
    response = HttpResponse(image.docfile, content_type='image/jpeg')
    response['Content-Disposition'] = 'attachment; filename=%s' % filename 

    return response

