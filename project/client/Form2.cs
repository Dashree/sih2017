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

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Files_Click(object sender, EventArgs e)
        { 
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.InitialDirectory = @"c:\\";
            openFile1.Filter = "Image Files(*.jpg)|*.jpg";
            openFile1.FilterIndex = 1;
            openFile1.Multiselect = true;
            openFile1.RestoreDirectory = true;
            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                string[] images = openFile1.FileNames;
                byte[] byte_code = new byte[images.Length];
                for (int i = 0; i < images.Length; i++)
                {
                    // byte_code[i] = Byte.Parse(images[i]);
                    //byte_code[i] = Convert.ToByte(openFile1.FileNames[i]);
                   byte_code = Encoding.ASCII.GetBytes(images[i]);
                }
                byte[] hash;
                SHA512 code = new SHA512Managed();
                hash = code.ComputeHash(byte_code);
            }
        }
    }
}
