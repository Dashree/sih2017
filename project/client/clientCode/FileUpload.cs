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
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace client
{
    public partial class FileUpload : Form
    {
        public object BarcodeType { get; private set; }
        private string collegeName, examcode;
        string url = "http:\\";
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
        private byte[] Hash_Compute(string filePath)
        {
            byte[] byte_code = this.ReadFileBytes(filePath);
            byte[] hash;
            SHA512 code = new SHA512Managed();
            hash = code.ComputeHash(byte_code);

            return hash;
        }

        private bool UploadInfo(string filePath, string image_name, byte[] hash)
        {
            //    byte[] image = GetBytesFromImage(filePath);
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //    request.Method = "POST";
            //    request.ContentType = "byte"; // to be changed
            //    request.ContentLength = image.Length;
            //    request.KeepAlive = false;
            //    request.AllowAutoRedirect = false;
            //   // request.AllowWriteStreamBuffering = false;
            // HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // if (response.StatusCode == HttpStatusCode.OK)
            // {
            WebClient client = new WebClient();
            byte[] hashResponse = client.UploadData(url, hash);
            if (hashResponse.ToString() == "true")
            {
                byte[] serverResponse = client.UploadFile(url, image_name);
                progressBar();
                return true;
            }
            else
            {
                return false;
            }


            // }
        }
        int i = 0;
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
            button1.ImageAlign = ContentAlignment.TopLeft;
            Controls.Add(button1);
            this.AutoScroll = true;
            //progressBar();

        }


        private bool QRCodeScan(string workBmp)
        {
            string extension = Path.GetExtension(workBmp);
            workBmp.Replace(extension, ".bmp");
            using (var fullImg = new Bitmap(workBmp))
            {
                Bitmap result = fullImg;
                //top-left
                var bandImg1 = result.Clone(new System.Drawing.Rectangle(0, 0, result.Width / 2, result.Height / 2), fullImg.PixelFormat);

                //top-right
                var bandImg2 = result.Clone(new System.Drawing.Rectangle(result.Width / 2, 0, result.Width / 2, result.Height / 2), fullImg.PixelFormat);
                //bottom-left
                var bandImg3 = result.Clone(new System.Drawing.Rectangle(0, result.Height / 2, result.Width / 2, result.Height / 2), fullImg.PixelFormat);
                //bottom-right
                var bandImg4 = result.Clone(new System.Drawing.Rectangle(result.Width / 2, result.Height / 2, result.Width / 2, result.Height / 2), fullImg.PixelFormat);

                //saving images for testing purpose just to see what was saved for each corner. 

                //bandImg1.Save("c:\\img.png", System.Drawing.Imaging.ImageFormat.Png);
                //bandImg2.Save("c:\\bandImg2.gif", System.Drawing.Imaging.ImageFormat.Gif);
                //bandImg3.Save("c:\\bandImg3.gif", System.Drawing.Imaging.ImageFormat.Gif);
                //bandImg4.Save("c:\\bandImg4.gif", System.Drawing.Imaging.ImageFormat.Gif);

                QRCodeDecoder decoder = new QRCodeDecoder();
                string QRinfo = (decoder.Decode(new QRCodeBitmapImage(bandImg1 as Bitmap)));
                //string QRinfo = Process(bandImg1);//this  should pass in the bandImg depending on the above search finding which corner has a qr image
                // MessageBox.Show(QRinfo);
                //textBox1.Text = QRinfo;
               //Ckeck if the QR  code matches with the exam code
                if(String.Compare(QRinfo, examcode) == 0)
                    return true;
                return false;
            }
        }



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
                    bool Qr = QRCodeScan(img, FilePath);
                    if (Qr == true)
                    {
                        byte[] hash = Hash_Compute(FilePath);
                        bool uploadResponse = UploadInfo(FilePath, FileName, hash);// sends the hash code and if it is not found image is uploaded
                        if (uploadResponse == true)// if uploaded image will be added
                            button(FilePath);
                    }

                    //UploadInfo(FilePath, FileName);
                    //send hash to server
                    //if at server skip file
                    //else call button() and uploadInfo()
                }



                // find image file list in the directory
                //  for each image
                // check if image contains qr code
                // if yes, check if qrcode text matches examcode
                //    if yes, calculate hash of the image
                    // if hash not at server upload the image, diaplay it to the user and increment value of progress bar
                     
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            collegeName = textBox1.Text;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            examcode = textBox2.Text;
        }

    }
}