from django.shortcuts import render

# Create your views here.

from django.template import RequestContext
from django.http import HttpResponseRedirect,HttpResponseNotFound,JsonResponse
from django.core.urlresolvers import reverse

from django.views.decorators.http import require_GET, require_POST

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
        scannedimage.save()

        response = { 'name' : scannedimage.docfile.name, }
        # Redirect to the document list after POST
        return JsonResponse(response)
    else:
        return HttpResponseNotFound("Unable to upload file")
