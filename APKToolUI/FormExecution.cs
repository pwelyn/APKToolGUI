using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

namespace APKToolGUI
{
    public partial class FormExecution : Form
    {
        public FormExecution(String[] arg)
        {
            SetLanguage();
            InitializeComponent();
            this.Icon = Properties.Resources.android_thin;

            args = arg;
        }

        private string javaExe = Properties.Settings.Default.JavaExe;
        private APKTool apkTool;
        private SignApk signApk;
        private String[] args;

        private static void SetLanguage()
        {
            String settingsCulture = Properties.Settings.Default.Culture;

            if (settingsCulture.Equals("Auto"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InstalledUICulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            }
            else
            {
                System.Globalization.CultureInfo _settingsCulture = System.Globalization.CultureInfo.GetCultureInfo(settingsCulture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = _settingsCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = _settingsCulture;
            }
        }

        private void FormExecution_Shown(object sender, EventArgs e)
        {
            if (!JavaSearch.TrySearchJava(ref javaExe))
            {
                MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Java location: " + javaExe));
            InitializeAPKTool();
            InitializeSignApk();
            CommandDetection();
        }

        private void CommandDetection()
        {
            switch (args[0])
            {
                case "b":
                    Building();
                    break;
                case "d":
                    Decompiling();
                    break;
                case "if":
                    InstallFramework();
                    break;
                case "sign":
                    Singning();
                    break;
                default:
                    ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Error, DateTime.Now, "Unknown command: \"" + args[0] + "\""));
                    break;
            }
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            CommandDetection();
        }

        #region apktool

        private void InitializeAPKTool()
        {
            apkTool = new APKTool(javaExe);
            apkTool.Exited += new EventHandler(_apktool_Exited);
            apkTool.OutputDataReceived += new MyDataReceivedEventHandler(_apktool_OutputDataReceived);
            apkTool.ErrorDataReceived += new MyDataReceivedEventHandler(_apktool_ErrorDataReceived);
            apkTool.Exception += new ExceptionEventHandler(_apktool_Exception);
        }

        private void Decompiling()
        {
            this.Text = "Decompiling: " + System.IO.Path.GetFileName(args[1]);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            apkTool.Decompiling(args[1],
                Properties.Settings.Default.noSrc,
                Properties.Settings.Default.noRes,
                Properties.Settings.Default.force,
                Properties.Settings.Default.framePathLocation);
        }

        private void Building()
        {
            this.Text = "Building: " + args[1];
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            String outputAPK = args[1] + DateTime.Now.ToString("_yyyyMMdd_HH-mm-ss") + ".apk";

            apkTool.Building(args[1],
                Properties.Settings.Default.buildAll,
                Properties.Settings.Default.AAPTFileLocation,
                outputAPK);
        }

        private void InstallFramework()
        {
            this.Text = "Installing framework: " + System.IO.Path.GetFileName(args[1]);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            apkTool.InstallFramework(args[1]);
        }

        #endregion

        #region signapk

        private void InitializeSignApk()
        {
            signApk = new SignApk(javaExe);
            signApk.Exited += new EventHandler(_apktool_Exited);
            signApk.OutputDataReceived += new MyDataReceivedEventHandler(_apktool_OutputDataReceived);
            signApk.ErrorDataReceived += new MyDataReceivedEventHandler(_apktool_ErrorDataReceived);
            signApk.Exception += new ExceptionEventHandler(_apktool_Exception);
        }

        private void Singning()
        {
            this.Text = "Singning: " + args[1];
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            signApk.Sign(args[1], null);
        }

        #endregion

        #region Events

        private void _apktool_OutputDataReceived(object sender, ProcessRun.OutData e)
        {
            //ToLog(e.Message);
            ToLog(e);
        }

        private void _apktool_ErrorDataReceived(object sender, ProcessRun.OutData e)
        {
            //ToLog(e.Message);
            ToLog(e);
        }

        private void _apktool_Exited(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                buttonRetry.Enabled = true;
            }));
            ToStatus(Language.Done, Properties.Resources.done);
        }

        private void _apktool_Exception(object sender, Exception e)
        {
            //ToLog(e.Message);
            buttonRetry.Enabled = true;
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Error, DateTime.Now, e.Message));
            MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Log&Status

        private void ToLog(string time, string message, Image statusImage, Color backColor)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                int i = dataGridView1.Rows.Add(statusImage, time, message);
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;

                dataGridView1.FirstDisplayedScrollingRowIndex = i;
            }));
        }

        private void ToStatus(string message, Image statusImage)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripStatusLabelStateText.Text = message;
                toolStripStatusLabelStateImage.Image = statusImage;
            }));
        }

        private void ToLog(ProcessRun.OutData outData)
        {
            ProcessRun.OutData result = APKTool.ParseLog(outData);
            switch (result.Stream)
            {
                case ProcessRun.StreamType.Info:
                    ToLog(result.Time.ToString("[dd.MM.yyyy HH:mm:ss]"), result.Message, Properties.Resources.info, Color.FromKnownColor(KnownColor.Window));
                    ToStatus(result.Message, Properties.Resources.info);
                    break;
                case ProcessRun.StreamType.Error:
                    ToLog(result.Time.ToString("[dd.MM.yyyy HH:mm:ss]"), result.Message, Properties.Resources.error, Color.FromKnownColor(KnownColor.LightPink));
                    ToStatus(result.Message, Properties.Resources.error);
                    break;
                case ProcessRun.StreamType.Warning:
                    ToLog(result.Time.ToString("[dd.MM.yyyy HH:mm:ss]"), result.Message, Properties.Resources.warning, Color.FromKnownColor(KnownColor.LightYellow));
                    ToStatus(result.Message, Properties.Resources.warning);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
