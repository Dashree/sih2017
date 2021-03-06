﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using clientCode;

namespace client
{
    public partial class LogIn : Form
    {
        string serverUrl = "http://localhost:8000";
        string loginUrl = "/user/login/";
     
        WebClient webclient = new CookieAwareWebClient();
        public LogIn()
        {
            InitializeComponent();
            this.serverUrl = serverUrl;
            this.loginUrl = this.serverUrl + this.loginUrl;
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd/  HH:mm:ss");
        }

        private bool login(string username, string password)
        {
            NameValueCollection login_params = new NameValueCollection();
            login_params.Add("username", username);
            login_params.Add("password", password);
            bool logged_in = true;
            try
            {
                byte[] responseArray = this.webclient.UploadValues(this.loginUrl, login_params);
                //string response = System.Text.Encoding.UTF8.GetString(serverResponse); 
            }
            catch (WebException exp)
            {
                HttpWebResponse response = (System.Net.HttpWebResponse)exp.Response;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    logged_in = false;
                }
            }
            return logged_in;
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
             if (login(userNameBox.Text, this.passwordBox.Text) == true)
            {
                string value = GetTimestamp(DateTime.Now);
                label3.Visible = false;
                this.Hide();
                FileUpload upload = new FileUpload(this.serverUrl, webclient, value);
              
                upload.Show();
             }
            else
            {
                label3.Visible = true;
                passwordBox.Clear();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
