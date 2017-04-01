import os
import subprocess
import shutil
import requests
import tempfile

def marks_detection_worker(imageid,examid):
    
    model_answer_template = r'C:\Python27\OMR_Templates\Template1\ModelAns.jpg'
    student_answer_sheet =  r'C:\Python27\OMR_Templates\Template1\Student1.jpg'
    os.chdir("C:\\Octave\\Octave-4.2.0\\bin")
    #process = subprocess.Popen(['octave.exe', '--eval "1+1"'], stdout=subprocess.PIPE)
    process = subprocess.Popen(['octave.exe',r'C:\Users\Admin-PC\Desktop\impython.m', 'shruti'], stdout=subprocess.PIPE)
    process.wait()
    response = process.stdout.read()
    print(response)
    
    
    
def download_image():
    url = 'http://www.axiome.ch/typo3temp/pics/14c77f8f8a.jpg'
    response = requests.get(url, stream=True)
    tempjpgpath = tempfile.gettempdir()
    tempjpgpath = os.path.join(tempjpgpath, '1.jpg')
    with open(tempjpgpath, "wb") as fjpg:
        fjpg.write(response.content)
    
if __name__ == "__main__":
    #marks_detection_worker(10, 10)
    download_image()
    