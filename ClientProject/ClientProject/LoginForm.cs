using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProject {
    public partial class LoginForm : Form {
        public string ShowCause {
            get { return labelControl1.Text; }
            set { labelControl1.Text = value; }
        }
        public string Token { get; private set; } = null;
        public string UriString { get; set; }
        public LoginForm() {
            InitializeComponent();
        }


        async private void simpleButton1_Click(object sender, EventArgs e) {
            if(await TryLoginAsync("Reader", "ReaderPassword")) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        async Task<bool> TryLoginAsync(string login, string password) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(UriString);
            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes($"{{\"login\": \"{login}\",\"password\": \"{password}\"}}");
            request.ContentType = "application/json; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = null;
            try {
                requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
            }
            catch(Exception e) {
                labelControl1.Text = "Login Failed: " + e.Message;
                return false;
            }
            finally {
                if(requestStream!= null)
                    requestStream.Dispose();
            }
            try {
                HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
                if(response.StatusCode == HttpStatusCode.OK) {
                    using(Stream stream = response.GetResponseStream()) {
                        using(StreamReader reader = new StreamReader(stream)) {
                            Token = reader.ReadToEnd();
                            return true;
                        }
                    }
                }
                else {
                    labelControl1.Text = "Login Failed: " + response.StatusDescription;
                }
                response.Close();
            }
            catch(Exception ex) {
                labelControl1.Text = "Login Failed: " + (ex.Message);
            }
            return false;
        }

        async private void simpleButton2_Click(object sender, EventArgs e) {
            if(await TryLoginAsync("Writer", "WriterPassword")) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        async private void simpleButton3_Click(object sender, EventArgs e) {
            if(await TryLoginAsync("Admin", "AdminPassword")) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
