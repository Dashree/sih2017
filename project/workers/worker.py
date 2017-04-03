import os
import subprocess
import shutil
import requests
import tempfile

/exam/<examid>/download/section/

def marks_detection_worker(imageid,examid):
    
    #download the scanned answersheet image based on image id
    #download the exam templates based on exam id
    model_answer_url = "http://localhost/exam/%s/download/modelanswer/" % examid
    model_answer_template = download_image(model_answer_url)
    model_answer_template = r'C:\Python27\OMR_Templates\Template1\ModelAns.jpg'
    student_answer_sheet =  r'C:\Python27\OMR_Templates\Template1\Student1.jpg'
    os.chdir("C:\\Octave\\Octave-4.2.0\\bin")
    #process = subprocess.Popen(['octave.exe',r'C:\Users\Admin-PC\Desktop\impython.m', 'shruti'], stdout=subprocess.PIPE)
    process.wait()
    marks = process.stdout.read()

    send_marks(url, examid, imageid, marks)
    

def send_marks(url, examid, imageid, marks):
    url = '/exam/<examid>/marks/<imageid>'
    request.post(url, marks)
    pass

def download_image(url):
    url = 'http://www.axiome.ch/typo3temp/pics/14c77f8f8a.jpg'
    response = requests.get(url, stream=True)
    tempjpgpath = tempfile.gettempdir()
    tempjpgpath = os.path.join(tempjpgpath, '1.jpg')
    with open(tempjpgpath, "wb") as fjpg:
        fjpg.write(response.content)
    return fjpg

if __name__ == "__main__":
    #marks_detection_worker(10, 10)
    download_image()
    
