import os
import subprocess
import shutil
import requests
import tempfile
from config import huey  # import our "huey" object

ANSWERPAPER_URL = "/%s/"
OCTAVE_PATH = "C:/ProgramFiles(x86)/Notepad++/notepad++.exe"

@huey.task()
def detect(host_name, examid, studentid, answerpaperid):
    model_answer_url = "exam/%s/download/modelanswer/" % examid
    student_answer_sheet =  r"^upload/image/%s/" % imageid
    url = host_name + (ANSWERPAPER_URL % answerpaperid)
    model_answer_template = download_image(url, 'ans%s" % answerpaperid)
    #model_answer_template = r'C:\Python27\OMR_Templates\Template1\ModelAns.jpg'
    
    os.chdir(OCTAVE_PATH)
    #process = subprocess.Popen(['octave.exe',r'C:\Users\Admin-PC\Desktop\impython.m', 'shruti'], stdout=subprocess.PIPE)
    process.wait()
    marks = process.stdout.read()
    send_marks(host_name, examid, studentid, answerpaperid, marks)
	File.delete(save=True)
    #delete downloaded images.

