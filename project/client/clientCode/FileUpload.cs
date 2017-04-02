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
        private int x = 0, y = 0;
        private int countSkip = 0, countUploaded = 0;
        private FileStream statusStream;
        private StreamWriter statusWriter;
        private string loginTime;

        public FileUpload(string serverUrl, WebClient webclient, string lgTime)
        {
            InitializeComponent();
            this.uploadUrl = serverUrl + this.cUploadUrl;
            this.cHash = serverUrl + this.cHash;
            this.client = webclient;
            this.loginTime = lgTime;
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
            return hash1; 
        }

        private bool IsHashAtServer(WebClient webclient, string hash)
        {
            int status;
           // bool hash_server = false;

            string hashurl = this.cHash + hash + "/";
            string response = webclient.DownloadString(hashurl);
            return response.IndexOf("true") >= 0;
        }

        private bool UploadImage(WebClient webclient, string studentid, string filePath)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    string url = String.Format(this.uploadUrl, ExamIdTxt.Text, studentid);
                    byte[] serverResponse = webclient.UploadFile(url, filePath);
                    return true;
                }
                catch
                {
                    //Retry
                }
            }
            return false;
        }

        //void progressBar()
        //{
        //    ProgressBar progressbar1 = new ProgressBar();
        //    progressbar1.Enabled = true;
        //    progressbar1.Value = i + 1;
        //    progressbar1.Location = new Point(318, 90);
        //    Controls.Add(progressbar1);
        //    label.Enabled = true;
        //    label.Visible = true;
        //    label.Location = new Point(318, 75);
        //    label.Text = progressbar1.Value + " images uploaded";
        //    Controls.Add(label);
        //    i++;
        //}

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

        private string UploadStatus(string response, string imgname)
        {
            Label lbl = new Label();
            lbl.Location = new Point(100, 210 + y);
            y = y + 80;
            lbl.AutoSize = true;
            if (response == "true")
            {
                countUploaded++;
                lbl.Text = imgname + " : Image Uploaded Successfully";
                lbl.ForeColor = Color.Green;
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                countSkip++;
                lbl.Text = imgname + " : *Image Skipped";
                lbl.ForeColor = Color.Red;
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            }
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
                if (String.Compare(qrExamId, ExamIdTxt.Text) == 0)
                    foundExamId = true;
            }
            catch (Exception exp)
            {
                foundExamId = false;
            }
            return foundExamId;
        }

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
            //Done with uploading... Exit now.
            System.Windows.Forms.Application.Exit();

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

        private void StartUploadClick(object sender, EventArgs e)
        {
           
            StatusFile = AppendTimeStamp(path);
            StatusFile = ImgeFolder.Text + "/" + StatusFile;
            this.statusStream = File.Open(StatusFile, FileMode.Create, FileAccess.ReadWrite);
            this.statusWriter= new StreamWriter(this.statusStream);

            SaveStatus("LogIn Time:" + loginTime);
            SaveStatus("*****************OMR Sheet Upload Status********************");

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
                            
                            bool ResponseUpload = this.UploadImage(this.client, studentid, imgpath);
                            MessageBox.Show(ResponseUpload.ToString());
                            button(imgpath);
                            string FileName = Path.GetFileNameWithoutExtension(imgpath);
                            string data = UploadStatus(ResponseUpload.ToString(), FileName);// create label and display on form
                            SaveStatus(data); // save in notepad
                        }
                        else
                        {
                            button(imgpath);
                            string FileName = Path.GetFileNameWithoutExtension(imgpath);
                            string data = UploadStatus("false", FileName);// create label and display on form
                            SaveStatus(data); // save in notepad
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
            
            SaveStatus("Number of uploaded images in this session : " + countUploaded.ToString());
            SaveStatus("Number of skipped images in this session : " + countSkip.ToString());
        }
    }
}