from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.

def index(request):
    return HttpResponse("Learning to upload and create database.")

##
##def get_ip_address(request):
##    """ use requestobject to fetch client machine's IP Address """
##    x_forwarded_for = request.META.get('HTTP_X_FORWARDED_FOR')
##    if x_forwarded_for:
##        ip = x_forwarded_for.split(',')[0]
##    else:
##        ip = request.META.get('REMOTE_ADDR')    ### Real IP address of client Machine
##    return ip
##
##def home(request):
##    """ your vies to handle http request """
##    ip_address = get_ip_address(request)
