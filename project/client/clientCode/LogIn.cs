using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace client
{
    public partial class LogIn : Form
    {   
        string serverUrl;
        string loginUrl = "/user/login/";
        
        WebClient webclient = new WebClient();
        public LogIn(string serverUrl)
        {
            InitializeComponent();
            this.serverUrl = serverUrl;
            this.loginUrl = this.serverUrl + this.loginUrl;
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
            }
            catch(WebException exp)
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
                this.Hide();
                FileUpload upload = new FileUpload(this.serverUrl);
                upload.Show();
            }
        }
    }
}
