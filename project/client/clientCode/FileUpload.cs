using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Diagnostics;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;

namespace client
{
    public partial class FileUpload : Form
    {
        public object BarcodeType { get; private set; }
        private string collegeName, examcode;
        private string StatusFile;
        private string cUploadUrl = "/upload/file/{0}/{1}/";
        private string cHash = "/upload/hash/";
        private string path = @"c:\temp\uploadStatus.txt";
        private String uploadUrl;
        private WebClient client;
        // string hashcode = @" C:\temp\hashcode.txt";
        private int x = 0;
        private int i = 0;
        private FileStream statusStream;
        private StreamWriter statusWriter;

        public FileUpload(string serverUrl, WebClient webclient)
        {
            InitializeComponent();
            this.uploadUrl = serverUrl + this.cUploadUrl;
            this.cHash = serverUrl + this.cHash;
            // [NITIN] Temporarily hardcode image list directory to c:\temp 
            // later ImageFolder path will be set from the FileOpenDialog
            // For testing copy the images to this directory.
            // this.ImgeFolder.Text = cImageListPath;
            this.client = webclient;
        }

        private void FileUpload_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private byte[] ReadFileBytes(String filepath)
        {
            byte[] buffer;
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            return buffer;
        }

        private string HashCompute(String FilePath)
        {
            byte[] byte_code = this.ReadFileBytes(FilePath);
            byte[] hash;
            SHA512 code = new SHA512Managed();
            hash = code.ComputeHash(byte_code);

            string hash1 = BitConverter.ToString(hash); // converting byte array to string
            hash1 = hash1.Replace("-", "");
            
           // SaveStatus(hash1, hashcode);
          
            return hash1;
           
        }

        private bool IsHashAtServer(WebClient webclient, string hash)
        {
            int status;
            bool hash_server = false;

            string hashurl = this.cHash + hash + "/";
            string response = webclient.DownloadString(hashurl);
           
            return response.IndexOf("true") >= 0;
        }

        private bool UploadImage(WebClient webclient, string studentid, string filePath)
        {
            string url = String.Format(this.uploadUrl, ExamIdTxt.Text, studentid);
            byte[] serverResponse = webclient.UploadFile(url, filePath);
            //string response = System.Text.Encoding.UTF8.GetString(serverResponse);
            return true;

        }

        void progressBar()
        {
            ProgressBar progressbar1 = new ProgressBar();
            progressbar1.Enabled = true;
            progressbar1.Value = i + 1;
            progressbar1.Location = new Point(318, 90);
            Controls.Add(progressbar1);
            label.Enabled = true;
            label.Visible = true;
            label.Location = new Point(318, 75);
            label.Text = progressbar1.Value + " images uploaded";
            Controls.Add(label);
            i++;
        }

        private void button(String imgPath)
        {
            Button button1 = new Button();
            button1.Location = new Point(40, 200 + x);
            button1.Height = 60;
            button1.Width = 60;
            x = x + 80;
            button1.BackgroundImage = Image.FromFile(imgPath);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.ImageAlign = ContentAlignment.TopLeft;
            Controls.Add(button1);
            button1.Show();
            this.AutoScroll = true;
            //progressBar();
        }
        //int count = 0;
        int y = 0;
        private string UploadStatus(string response, string imgname)
        {
            Label lbl = new Label();
            lbl.Location = new Point(100, 210 + y);
            y = y + 80;
            lbl.AutoSize = true;
            if (response == "true")
                lbl.Text = imgname + " : Image Uploaded Successfully";
            else
                lbl.Text = imgname + " : Image Skipped";
            Controls.Add(lbl);
            return lbl.Text;
        }
        private void SaveStatus(string data)
        {
            this.statusWriter.WriteLine(data);
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd  HH:mm:ss");
        }

        private bool IsExamIdFoundInQRCode(string imagepath, string examid)
        {
            bool foundExamId = false;
            try
            {
                Bitmap imgBmp = new Bitmap(Image.FromFile(imagepath, true));
                LuminanceSource src = new RGBLuminanceSource(imgBmp, imgBmp.Width, imgBmp.Height);
                Binarizer binarizer = new HybridBinarizer(src);
                BinaryBitmap imgBinarybmp = new BinaryBitmap(binarizer);
                QRCodeReader reader = new QRCodeReader();
                Result qrDecode = reader.decode(imgBinarybmp);
                String qrExamId = qrDecode.ToString();
                MessageBox.Show(qrExamId);
                if (String.Compare(qrExamId, ExamIdTxt.Text) == 0)
                    foundExamId = true;
            }
            catch (Exception exp)
            {
                foundExamId = false;
            }
            return foundExamId;
        }

        /*
         [NITIN] This function has somewhat confusing logic. I am keeping it for
         * reference. To be deleted later.
        private void Files_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder1 = new FolderBrowserDialog();
            if (openFolder1.ShowDialog() == DialogResult.OK)
            {

                string folderPath = openFolder1.SelectedPath;
                string[] Images = Directory.GetFiles(folderPath, "*.jpg"); //returns a file list from current directory
                MessageBox.Show(Images.Length.ToString());
                foreach (string img in Images)
                {
                    FileInfo path = new FileInfo(img.ToString());
                    string FilePath = path.FullName;
                    string FileName = Path.GetFileNameWithoutExtension(FilePath);
                    bool Qr = QRCodeScan(FilePath);
                    if (Qr == true)
                    {
                        //Read Image File into Image object.
                        //Image image = Image.FromFile(FilePath);

                        //ImageConverter Class convert Image object to Byte array.
                       //byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
                       byte[] hash = Hash_Compute(FilePath);
                       //byte[] hash = Hash_Compute(image);
                      //byte[] hash = Hash_Compute(bytes);
                        bool uploadResponse = UploadInfo(FilePath, FileName, hash);// sends the hash code and if it is not found image is uploaded
                        if (uploadResponse == true)// if uploaded image will be added
                            button(FilePath);
                    }

                    //UploadInfo(FilePath, FileName);
                    //send hash to server
                    //if at server skip file
                    //else call button() and uploadInfo()
                }



            }
        }
        */

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            collegeName = CollegeIdTxt.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            examcode = ExamIdTxt.Text;
        }

        private void DirDialogBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder1 = new FolderBrowserDialog();
            if(openFolder1.ShowDialog() == DialogResult.OK)
            {
                ImgeFolder.Text = openFolder1.SelectedPath;
                UploadBtn.Enabled = true;
            }
        }
        private void Logout(String statusfile)
        {
            String LogoutTimeStamp = GetTimestamp(DateTime.Now);
            SaveStatus( "Logout Time Stamp : " + LogoutTimeStamp);

            this.statusWriter.Close();
            this.statusStream.Close();
            Process process;
            process = Process.Start(statusfile);
            process.WaitForExit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Logout(StatusFile);
            this.Hide();
            LogIn login = new LogIn();
            login.Show();
        }
        private string AppendTimeStamp(string fileName)
        {
           string WithoutExt = Path.GetFileNameWithoutExtension(fileName);
           string DtStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
           string Ext = Path.GetExtension(fileName);
           string StatusFile = WithoutExt + DtStamp + Ext;
           return StatusFile; 
        }

        private void ExamIdTxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private string getStudentId(string imgpath)
        {
            string dummyStudentId = DateTime.Now.ToString("yyyyMMddHHmmss");
            return dummyStudentId;
        }
    

        //private bool Retry()
        //{
        //    Button button2 = new Button();
        //    button2.Location = new Point(90, 155 + x);
        //    button2.Height = 60;
        //    button2.Width = 60;
        //    x = x + 80;
        //    button2.Text = "Retry";
        //    if (button2.Click)
        //        return true;
        //    return false;
        //}
        private void StartUploadClick(object sender, EventArgs e)
        {
            StatusFile = AppendTimeStamp(path);
            StatusFile = ImgeFolder.Text + "/" + StatusFile;
            this.statusStream = File.Open(StatusFile, FileMode.Create, FileAccess.ReadWrite);
            this.statusWriter= new StreamWriter(this.statusStream);

            SaveStatus("OMR Sheet Upload Status");

            String UploadTimeStamp = GetTimestamp(DateTime.Now);
            SaveStatus("Upload Time:" + UploadTimeStamp);
            String dirpath = ImgeFolder.Text;
            // find image file list in the directory

            string[] filelist = Directory.GetFiles(dirpath, "*.jpg");

            foreach (String imgpath in filelist)
            {
                try
                {
                    // label:
                    bool Qr = IsExamIdFoundInQRCode(imgpath, this.ExamIdTxt.Text);

                    if (Qr == true)     //If QR code is right file is uploaded else skipped(nothing done)
                    {

                        string hash = HashCompute(imgpath);
                        bool hashServer = IsHashAtServer(this.client, hash);
                        if (hashServer == false)
                        {
                            string studentid = getStudentId(imgpath);
                            this.UploadImage(this.client, studentid, imgpath);
                            button(imgpath);
                            string FileName = Path.GetFileNameWithoutExtension(imgpath);
                            string data = UploadStatus("true", FileName);// create label and display on form
                            SaveStatus(data); // save in notepad
                        }
                        else
                        {
                            button(imgpath);
                            string FileName = Path.GetFileNameWithoutExtension(imgpath);
                            string data = UploadStatus("false", FileName);// create label and display on form
                            SaveStatus( data); // save in notepad
                                                            //bool retryResponse = Retry();
                                                            //if (retryResponse == true)
                                                            //    goto label;
                        }
                    }
                    else
                    {
                        button(imgpath);
                        string FileName = Path.GetFileNameWithoutExtension(imgpath);
                        string data = UploadStatus("false", FileName);// create label and display on form
                        SaveStatus(data); // save in notepad

                    }
                    // for each image

                    //check if image contains qr code
                    //  if yes, check if qrcode text matches examcode
                    //     if yes, calculate hash of the image
                    //  if hash not at server upload the image, display it to the user and increment value of progress bar



                }
                catch
                {
                    // In case of any exception, try the next file.
                }
            }
            
            
            //Done with uploading... Exit now.
         //  System.Windows.Forms.Application.Exit();
        }
    }
}