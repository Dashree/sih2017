﻿using System;
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

using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;

namespace client
{
    public partial class FileUpload : Form
    {
        public object BarcodeType { get; private set; }
        private string collegeName, examcode;
        string cServer = "http://localhost:8000";
        string cUploadUrl = "/upload/file/";
        string cImageListPath = @"c:\temp";
        String uploadUrl;
        int x = 0;
        int i = 0;

        public FileUpload()
        {
            InitializeComponent();
            this.uploadUrl = this.cServer + this.cUploadUrl;
            // [NITIN] Temporarily hardcode image list directory to c:\temp 
            // later ImageFolder path will be set from the FileOpenDialog
            // For testing copy the images to this directory.
            this.ImgeFolder.Text = cImageListPath;
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
            MessageBox.Show(buffer.ToString());
            return buffer;
        }

        private byte[] Hash_Compute(String FilePath)
        {
            byte[] byte_code = this.ReadFileBytes(FilePath);
            byte[] hash;
            SHA512 code = new SHA512Managed();
            hash = code.ComputeHash(byte_code);
           // MessageBox.Show(hash.ToString());
            return hash;
        }

        private bool UploadImage(WebClient webclient, string filePath)
        {
            byte[] serverResponse = webclient.UploadFile(this.uploadUrl, filePath);
            //string response = System.Text.Encoding.UTF8.GetString(serverResponse);
            //MessageBox.Show(response);
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
            button1.Location = new Point(40, 150 + x);
            button1.Height = 60;
            button1.Width = 60;
            x = x + 80;
            button1.BackgroundImage = Image.FromFile(imgPath);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.ImageAlign = ContentAlignment.TopLeft;
            Controls.Add(button1);
            this.AutoScroll = true;
            //progressBar();

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
            catch
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

        private void StartUploadClick(object sender, EventArgs e)
        {
            String dirpath = ImgeFolder.Text;
            // find image file list in the directory

            string[] filelist = Directory.GetFiles(dirpath);
            
            WebClient client = new WebClient();
            
            foreach(String imgpath in filelist)
            {
                bool Qr = IsExamIdFoundInQRCode(imgpath, this.ExamIdTxt.Text);
                //if (Qr == true)     //If QR code is right file is uploaded else skipped(nothing done)
                {
                    this.UploadImage(client, imgpath);
                    //  for each image
                    // check if image contains qr code
                    // if yes, check if qrcode text matches examcode
                    //    if yes, calculate hash of the image
                    // if hash not at server upload the image, display it to the user and increment value of progress bar

                }
            }
               
        }
    }
}