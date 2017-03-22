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
//using PQScan.BarcodeScanner;

namespace client
{
    public partial class FileUpload : Form
    {
        public object BarcodeType { get; private set; }

        public FileUpload()
        {
            InitializeComponent();
        }

        private void FileUpload_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private byte[] GetBytesFromImage(String imageFile)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    Image img = Image.FromFile(imageFile);
        //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return ms.ToArray();
        //}

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

        ////private int hash_send()
        ////{ 

        ////}
        private byte[] Hash_Compute(string filePath)
        {
            byte[] byte_code = this.ReadFileBytes(filePath);
            byte[] hash;
            SHA512 code = new SHA512Managed();
            hash = code.ComputeHash(byte_code);
        
            return hash;
        }
        //private void UploadFile(string filePath, string image_name)
        //{
        //    byte[] image = GetBytesFromImage(filePath);
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://");
        //    request.Method = "POST";
        //    request.ContentType = "byte"; // to be changed
        //    request.ContentLength = image.Length;
        //    request.KeepAlive = false;
        //    request.AllowAutoRedirect = false;
        //   // request.AllowWriteStreamBuffering = false;
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        WebClient client = new WebClient();
        //        byte[] serverResponse = client.UploadFile("http://", image_name);
        //        ProgressBar progressbar1 = new ProgressBar();
        //        progressbar1.Enabled = true;
        //       // progressbar1.Value = ;
        //        Controls.Add(progressbar1);
        //    }
        //}
        int x = 0;
        private void button(String imgPath)
        {
            Button button1 = new Button();
            button1.Location = new Point(40, 150 + x);
            button1.Height = 60;
            button1.Width = 60;
            x = x + 80;
            button1.BackgroundImage = Image.FromFile(imgPath);
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.ImageAlign = ContentAlignment.MiddleCenter;
            Controls.Add(button1);
            this.AutoScroll = true;
        }


        //private void QRCodeScan(string img, string examcode)
        //{
        //    BarcodeResult[] results = BarCodeScanner.Scan(img, BarCodeType.QRCode);
        //    foreach(BarcodeResult result in results)
        //    {
        //        if(textBox2.Text == result.ToString())
        //        {
        //           // Hash_Compute(filePath);
        //        }
        //    } 
        //}

        private void Files_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog openFolder1 = new FolderBrowserDialog();
           
            //openFolder1.InitialDictionary = @"c:\\";
            //openFolder1.Filter = "Image Files(*.jpg)|*.jpg";
            //openFolder1.FilterIndex = 1;
            //openFolder1.Multiselect = true;
            //openFolder1.RestoreDirectory = true;
            if (openFolder1.ShowDialog() == DialogResult.OK)
            {
                    string folderPath = openFolder1.SelectedPath;
                    string[] Images = Directory.GetFiles(folderPath, "*.jpg"); //returns a file list from current directory
                    MessageBox.Show(Images.Length.ToString());
                    foreach(string img in Images)
                    {
                        FileInfo path = new FileInfo(img.ToString());
                        string FilePath = path.FullName;
                        string FileName = Path.GetFileNameWithoutExtension(FilePath);
                        button(FilePath);
                        // QRCodeScan(img);
                        byte[] hash = Hash_Compute(FilePath);
                   
                        //send hash to server
                        //if at server skip file
                            //else call button() and uploadFile()
                     }



                // find image file list in the directory
                //  for each image
                // check if image contains qr code
                // if yes, check if qrcode text matches examcode
                //    if yes, calculate hash of the
            }
        }
    }
}
