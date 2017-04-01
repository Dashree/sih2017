from django.shortcuts import render
from django.http import HttpResponse
from django.shortcuts import render, redirect
from django.contrib.auth import authenticate, login
from django.views.generic import View
from .forms import RegisterUser
from .upload import views

# Create your views here.

def index(request):
    return HttpResponse("Learning to upload and create database.")

class RegisterUserView(View):
    form_class = RegisterUser
    template_name='registrations_form.html'

    def get(self, request):             #display blank form
        form = self.form_class(None)
        return render(request, self.template_name, {'form' : form})


    def post(self, request):            #process form data
        form = self.form_class(request.POST)

        if form.is_valid():
            user = form.save(commit=False)

            username = form.cleaned_data['username']
            password = form.cleaned_data['password']
            user.set_password(password)
            user.save()

            #returns User objects if credantials are correct
            user = authenticate(username=username, password=password)

            if user is not None:
                if user.is_active:
                    login(request, user)
                    return redirect('http://127.0.0.1:8000/upload/list/')

        return render(request, self.template_name, {'form':form})



def login_user(request):
    if request.method == "POST":
        username = request.POST['username']
        password = request.POST['password']
        user = authenticate(username=username, password=password)
        if user is not None:
            if user.is_active:
                login(request, user)

                return redirect('upload:list')
            else:
                return render(request, 'login.html', {'error_message': 'Your account has been disabled'}, status=401)
        else:
            return render(request, 'login.html', {'error_message': 'Invalid login'},status=401)
    return render(request, 'login.html')

#   Getting IP address of the client
def get_client_ip(request):
    x_forwarded_for = request.META.get('HTTP_X_FORWARDED_FOR')
    if x_forwarded_for:
        ip = x_forwarded_for.split(',')[0]
    else:
        ip = request.META.get('REMOTE_ADDR')
    return ip
