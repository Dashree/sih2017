import os
import subprocess
import shutil
import requests
import tempfile

from config import huey  # import our "huey" object
from tasks import detect_marks, store_image  # import our task
#/exam/<examid>/download/section/

def marks_detection_worker(imageid,examid):
    
    #download the scanned answersheet image based on image id
    #download the exam templates based on exam id
    model_answer_url = "http://localhost/exam/%s/download/modelanswer/" % examid
    student_answer_sheet =  r'C:\sih2017\testdata\templates\omr5new.jpg'
    
    marks = detect(model_answer_url, student_answer_sheet)
    print('hello')
    send_marks(url, examid, imageid, marks)
    

def send_marks(url, examid, imageid, marks):
##    url = '/exam/<examid>/marks/<imageid>'
##    request.post(url, marks)
    return 'hello'

def download_image(url):
    #url = 'C:\sih2017\testdata\templates\omr4new.jpg'
    response = requests.get(url, stream=True)
    return 'checked'

##if __name__ == "__main__":
##    #marks_detection_worker(10, 10)
##    download_image(url)
    
