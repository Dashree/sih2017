using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace client
{
    public partial class LogIn : Form
    {   string url = "http://127.0.0.1:8000/user/login/";
        private string[] username = { "Lavina", "Shruti", "Snigdha", "Akshata"};
        private string[] password = { "123$", "qwer", "asdf", "zxcv" };
        public LogIn()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        //private int verification(string username, string password)
        //{
        //    WebClient verify = new WebClient();
        //    byte[] verifyResponse1 = verify.UploadFile(url, username);
        //    if (verifyResponse1.ToString() == "true")
        //    {
        //        byte[] verifyResponse2 = verify.UploadFile(url, password);
        //        if (verifyResponse2.ToString() == "true")
        //        {
        //            return 1;
        //        }
        //        return 0;
        //    }
        //    return 0;
        //}

        private int verify(string pass, int j)
        {

            if (password[j] == pass)
                return 1;
            else
                return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //label3.Visible = false;
            //int flag = verification(textBox1.Text, textBox2.Text);
            //if (flag == 1)
            //{
            //    this.Hide(); // to Hide Form1
            //    //To open the Form2
            //    client.FileUpload upload = new FileUpload();
            //    upload.Show();
            //    textBox1.Clear();
            //    textBox2.Clear();
            //}
            //else
            //{
            //    label3.Visible = true;
            //    textBox2.Clear();

            //}
            int i = 0;
            foreach (string name in username)
            {
                label3.Visible = false;

                if (String.Compare(textBox1.Text, name) == 0)
                {
                    int flag = verify(textBox2.Text, i);
                    if (flag == 1)
                    {
                        this.Hide();
                        //FileUpload show
                        FileUpload upload = new FileUpload();
                        upload.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        break;
                    }
                    else
                    {
                        label3.Visible = true;
                        textBox2.Clear();

                    }
                }
                else
                {
                    textBox2.Clear();
                    label3.Visible = true;
                }
                i++;
            }
            //this.Show(); : show LogIn
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
