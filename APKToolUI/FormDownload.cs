using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace APKToolGUI
{
    public partial class FormDownload : Form
    {
        public FormDownload()
        {
            InitializeComponent();
        }

        private void UpdateApplication()
        {
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            string userAgentString = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Win64; x64; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0; .NET4.0C; .NET4.0E)";
            client.Headers.Add("user-agent", userAgentString);
            Uri ui = new Uri("http://infinum.orgfree.com/_Update/APKToolGUI/Update.upd");
            try
            {
                client.DownloadFileAsync(ui, Application.StartupPath + @"\Update.upd");
            }
            catch (Exception e)
            {
                File.Delete(Application.StartupPath + @"\Update.upd");
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            File.Move(Application.StartupPath + @"\Update.upd", Application.StartupPath + @"\Update.exe");
            Process.Start(Application.StartupPath + @"\Update.exe");
            //throw new NotImplementedException();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //throw new NotImplementedException();
        }

        private void FormDownload_Load(object sender, EventArgs e)
        {
            UpdateApplication();
        }
    }
}
