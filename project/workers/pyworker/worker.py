import os
import subprocess
import shutil
import requests
import tempfile
import re
    
from hueyconfig import huey  # import our "huey" object

ANSWERPAPER_URL = "/upload/image/%s/"
OCTAVE_PATH = "C:/temp"

@huey.task()
def detect(host_name, examid, studentid, scannedimageid):
    print("downloading mage")
    model_answer_url = "exam/%s/download/modelanswer/" % examid
    url = host_name + (ANSWERPAPER_URL %scannedimageid)
    scanned_image_path = download_image(url)
    print(scanned_image_path)
    #model_answer_template = r'C:\Python27\OMR_Templates\Template1\ModelAns.jpg'
    
    os.chdir(OCTAVE_PATH)
    #process = subprocess.Popen(['octave.exe',r'C:\Users\Admin-PC\Desktop\impython.m', 'shruti'], stdout=subprocess.PIPE)
    #process.wait()
    #marks = process.stdout.read()
    #send_marks(host_name, examid, studentid, scannedimageid, marks)
    #delete downloaded images.

@huey.task()
def worker_test(host_name, examid):
    print(host_name)
    print(examid)

def send_marks(url, examid, scannedimageid, marks):
    url = '/exam/%s/marks/%d' %examid %imageid
    download_image(url)

def download_image(url):
    print(url)
    #url = 'http://www.axiome.ch/typo3temp/pics/14c77f8f8a.jpg'
    response = requests.get(url, stream=True)
    d = response.headers['content-disposition']
    filename = re.findall("filename=(.+)", d)[0]

    tempjpgpath = tempfile.gettempdir()
    tempjpgpath = os.path.join(tempjpgpath, filename)
    with open(tempjpgpath, "wb") as fjpg:
        fjpg.write(response.content)
    return tempjpgpath

if __name__  == '__main__':
    detect('http://localhost:8000',2,1,2)

