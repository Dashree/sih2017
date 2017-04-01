from django.shortcuts import render
from .models import ScannedImage

from django.template import RequestContext
from django.http import HttpResponseRedirect,HttpResponseNotFound,JsonResponse
from django.core.urlresolvers import reverse

from django.views.decorators.http import require_GET, require_POST
from exam.models import ExamInfo
from .models import ScannedImage
from .forms import DocumentForm


@require_GET
def file_list(request):
    '''
    show list of uploaded file.
    '''
    form = DocumentForm()  # A empty, unbound form
    # Load documents for the list page
    documents = ScannedImage.objects.all()
    #assert len(documents) > 0
    # Render list page with the documents and the form
    return render(
       request,
        'list.html',
        {'documents': documents, 'form': form}
    )

@require_POST
def upload_file(request):
    '''
    upload single file
    '''
    if 'file' in request.FILES:
        scannedimage = ScannedImage(docfile=request.FILES['file'])
        scannedimage.full_clean()
        scannedimage.save()

        response = { 'name' : scannedimage.docfile.name, }
        # Redirect to the document list after POST
        return JsonResponse(response)
    else:
        return HttpResponseNotFound("Unable to upload file")

@require_GET
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
    
@require_POST
def download_template(request, examid):
    '''
    give download url to workers
    '''
    template=ExamInfo.objects.filter(id=examid)
    return JsonResponse(template.template)      #examid is passed by the url and equivalent to the default id of ExamInfo table
