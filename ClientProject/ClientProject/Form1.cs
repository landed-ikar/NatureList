using DevExpress.XtraRichEdit;
using Newtonsoft.Json;
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
    public partial class Form1 : Form {
        readonly string rootUriString = "https://localhost:7135/api";
        readonly string loginUriString = "https://localhost:7135/api/Login";
        readonly string dataUriString = "https://localhost:7135/api/NatureList";

        string token = string.Empty;
        public Form1() {
            InitializeComponent();
            rec_XmlFileContent.LoadDocument(@"Data.xml", DocumentFormat.PlainText);
        }

        private void btn_OpenXml_Click(object sender, EventArgs e) {
            DialogResult result = xmlOpenFileDialog.ShowDialog(this);
            if(result == DialogResult.OK) {
                rec_XmlFileContent.LoadDocument(xmlOpenFileDialog.FileName, DocumentFormat.PlainText);
            }
        }
        private async void btn_SendXml_Click(object sender, EventArgs e) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(dataUriString);
            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes(rec_XmlFileContent.Text);
            request.ContentType = "application/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            request.Headers.Add(HttpRequestHeader.Authorization , "Bearer " + token);
            Stream requestStream = null;
            try {
                requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
            }
            catch(Exception ex) {
                Log("Data sending failed: " + ex.Message);
            }
            finally {
                requestStream.Close();
            }
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)(await request.GetResponseAsync());
                if(response.StatusCode == HttpStatusCode.NoContent)
                    Log("Data sending successful");
                else
                    Log("Data sending failed:" + response.StatusDescription);
            }
            catch(WebException ex) {
                HttpWebResponse exResponse = (HttpWebResponse)ex.Response;
                if(exResponse.StatusCode == HttpStatusCode.Unauthorized) {
                    Log("Login failed. Try to relogin.");
                    if(!TryLogin())
                        Close();
                }
                else {
                    Log("Data sending failed: " + ex.Message);
                }
            }
            catch(Exception ex) {
                Log("Data sending failed: " + ex.Message);
            }
            finally {
                if(response!= null)
                    response.Dispose();
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            if(!TryLogin())
                Close();
        }
        bool TryLogin() {
            using(LoginForm form = new LoginForm() { UriString = loginUriString }) {
                DialogResult result = form.ShowDialog();
                if(result == DialogResult.OK) {
                    token = form.Token;
                    Log("Successful Login");
                    return true;
                }
                return false;
            }
        }
        void Log(string text) {
            me_Log.Text += text + Environment.NewLine; 
        }

        private async void btn_GetReport_Click(object sender, EventArgs e) {
            WebRequest request = WebRequest.Create(dataUriString + "/" + te_TrainNumber.Text + ".xlsx");
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)(await request.GetResponseAsync());
                if(response.StatusCode == HttpStatusCode.OK) {
                    Log("Report getting successful");
                    spr_Report.LoadDocument(response.GetResponseStream());
                }
                else
                    Log("Report getting failed:" + response.StatusDescription);
            }
            catch(WebException ex) {
                HttpWebResponse exResponse = (HttpWebResponse)ex.Response;
                if(exResponse.StatusCode == HttpStatusCode.Unauthorized) {
                    Log("Login failed. Try to relogin.");
                    if(!TryLogin())
                        Close();
                }
                else {
                    using(StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), System.Text.Encoding.UTF8)) {
                        string errorMessage = reader.ReadToEnd();
                        Log("Data getting failed: " + errorMessage);
                    }
                }
            }
            catch(Exception ex) {
                Log("Data getting failed: " + ex.Message);
            }
            finally {
                if(response != null)
                    response.Dispose();
            }
        }

        private async void btn_GetNlJson_Click(object sender, EventArgs e) {
            WebRequest request = WebRequest.Create(dataUriString + "/" + te_TrainNumber.Text + ".json");
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)(await request.GetResponseAsync());
                if(response.StatusCode == HttpStatusCode.OK) {
                    Log("Report getting successful");
                    using(StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8)) {
                        string json = reader.ReadToEnd();
                        rec_JsonData.Text = JsonConvert.DeserializeObject(json).ToString();
                    }
                }
                else
                    Log("Report getting failed:" + response.StatusDescription);
            }
            catch(WebException ex) {
                HttpWebResponse exResponse = (HttpWebResponse)ex.Response;
                if(exResponse.StatusCode == HttpStatusCode.Unauthorized) {
                    Log("Login failed. Try to relogin.");
                    if(!TryLogin())
                        Close();
                }
                else {
                    using(StreamReader reader = new StreamReader(ex.Response.GetResponseStream(), System.Text.Encoding.UTF8)) {
                        string errorMessage = reader.ReadToEnd();
                        Log("Data getting failed: " + errorMessage);
                    }
                }
            }
            catch(Exception ex) {
                Log("Data getting failed: " + ex.Message);
            }
            finally {
                if(response != null)
                    response.Dispose();
            }

        }

    }
}
