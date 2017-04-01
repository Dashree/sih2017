from django.shortcuts import render
from django.http import HttpResponse
from django.contrib.auth.decorators import login_required
from django.views.decorators.http import require_GET, require_POST

# Create your views here.
@require_GET
def index(request):
    return HttpResponse("Exams app")



