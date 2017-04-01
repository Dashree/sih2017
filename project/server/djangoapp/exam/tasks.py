import os
import subprocess
import shutil
import requests
import tempfile
from config import huey  # import our "huey" object

def detect_marks(model_ans, student_ans):
    
    
    model_answer_template = download_image(model_ans)
    #model_answer_template = r'C:\Python27\OMR_Templates\Template1\ModelAns.jpg'
    
    os.chdir("C:\\Octave\\Octave-4.2.0\\bin")
    #process = subprocess.Popen(['octave.exe',r'C:\Users\Admin-PC\Desktop\impython.m', 'shruti'], stdout=subprocess.PIPE)
    process.wait()
    marks = process.stdout.read()
    return marks


def store_image():
    tempjpgpath = tempfile.gettempdir()
    tempjpgpath = os.path.join(tempjpgpath, 'omr3new.jpg')
    with open(tempjpgpath, "wb") as fjpg:
        fjpg.write(response.content)
    return fjpg
    
