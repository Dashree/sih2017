from django.shortcuts import render
from django.http import HttpResponse
from django.shortcuts import render, redirect
from django.contrib.auth import authenticate, login
from django.views.generic import View
from .forms import UserForm

# Create your views here.

def index(request):
    return HttpResponse("Learning to upload and create database.")

class UserFormView(View):
    form_class = UserForm
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
                    return redirect('upload: index')

        return render(request, self.template_name, {'form':form})

    
