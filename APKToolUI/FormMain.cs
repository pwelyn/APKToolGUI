using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace APKToolGUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            SetLanguage();
            InitializeComponent();
            InitializeMainMenu();
            this.Icon = Properties.Resources.android_thin;
            this.Text += " - v" + ProductVersion;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (!JavaSearch.TrySearchJava(ref javaExe))
            {
                if (MessageBox.Show(Language.DoYouWantToSelectJavaLocation, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    OpenFileDialog openJavaExe = new OpenFileDialog()
                    {
                        Multiselect = false,
                        Filter = "java.exe|java.exe"
                    };
                    if (openJavaExe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Properties.Settings.Default.JavaExe = openJavaExe.FileName;
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else
                        Application.Exit();
                }
                else
                    Application.Exit();
            }
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Java location: " + javaExe));

            InitializeUpdateChecker();
            InitializeAPKTool();
            InitializeSignApk();
            InitializeProcessRun();

            String javaVersion = GetJavaVersion();
            if (javaVersion != null)
            {
                ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Java version: " + javaVersion));

                string apktoolVersion = new APKTool(javaExe).GetVersion();

                if (apktoolVersion != null)
                {
                    ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "APKTool version: " + apktoolVersion));
                }
            }
            else
            {
                
                MessageBox.Show(Language.ErrorJavaDetect, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if (Properties.Settings.Default.LastUpdateCheck != null)
            //{
                TimeSpan updateInterval = DateTime.Now - Properties.Settings.Default.LastUpdateCheck;
                if (updateInterval.Days > 0 && Properties.Settings.Default.CheckForUpdateAtStartup)
                    updateCheker.CheckAsync(true);
            //}
            //else
            //    updateCheker.CheckAsync(true);
            ToStatus(Language.Done, Properties.Resources.done);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private string javaExe = Properties.Settings.Default.JavaExe;
        private APKTool apkTool;
        private SignApk signApk;
        private UpdateChecker updateCheker;
        private ProcessRun zipAlign;

        #region главное меню

        private void InitializeMainMenu()
        {
            MainMenu mainMenu1 = new MainMenu();
            MenuItem menuItemFile = new MenuItem(Language.File);
            MenuItem menuItemHelp = new MenuItem(Language.Help);
            menuItemFile.MenuItems.Add(Language.Settings).Click += new EventHandler(Settings_Click);
            menuItemFile.MenuItems.Add(Language.Exit).Click += new EventHandler(Exit_Click);
            menuItemHelp.MenuItems.Add(Language.CheckForUpdate).Click += new EventHandler(Update_Click);
            menuItemHelp.MenuItems.Add(Language.About).Click += new EventHandler(About_Click);
            mainMenu1.MenuItems.Add(menuItemFile);
            mainMenu1.MenuItems.Add(menuItemHelp);
            this.Menu = mainMenu1;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            updateCheker.CheckAsync();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            //настройки
            FormSettings frm = new FormSettings();
            frm.ShowDialog();
            //MessageBox.Show(qwe.MenuItems[0].Text);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About_Click(object sender, EventArgs e)
        {
            FormAboutBox frm = new FormAboutBox();
            frm.ShowDialog();
        }

        #endregion

        #region Controls

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialogFramework.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialogFramework.FileName;
            }
            else
                return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                MessageBox.Show(Language.WarningFrameworkNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                tabControl1.Enabled = false;
                ClearLog();
                InstallFramework();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialogApk.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialogApk.FileName;
                textBox3.Text = Path.GetDirectoryName(textBox2.Text) + @"\" + Path.GetFileNameWithoutExtension(textBox2.Text);
            }
            else
                return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show(Language.WarningFileForDecodingNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                tabControl1.Enabled = false;
                ClearLog();
                Decompiling();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show(Language.WarningDecodingFolderNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                tabControl1.Enabled = false;
                ClearLog();
                Building();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox3.Text))
                folderBrowserDialogBuild.SelectedPath = textBox3.Text;
            if (folderBrowserDialogBuild.ShowDialog() == DialogResult.OK)
                textBox3.Text = folderBrowserDialogBuild.SelectedPath;
            else
                return;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "")
                Singning();
            else
                MessageBox.Show(Language.WarningFileForSigningNotSelected, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (openFileDialogSignApk.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialogSignApk.FileName;
                textBox6.Text = Path.GetDirectoryName(textBox5.Text) + @"\" + Path.GetFileNameWithoutExtension(textBox5.Text) + "_signed" + Path.GetExtension(textBox5.Text);
            }
            else
                return;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (saveFileDialogSignApkOut.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = saveFileDialogSignApkOut.FileName;
            }
            else
                return;
        }

        private void buttonFramePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frameDirDialog = new FolderBrowserDialog();
            frameDirDialog.ShowNewFolderButton = false;

            if (frameDirDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxFramePath.Text = frameDirDialog.SelectedPath;
        }

        private void buttonInputZipalign_Click(object sender, EventArgs e)
        {
            if (radioButtonFileZipalign.Checked && !radioButtonFolderZipalign.Checked)
            {
                OpenFileDialog inputZipalignFiles = new OpenFileDialog()
                {
                    Multiselect = false,
                    Filter = "Android App|*.apk"
                };
                if (inputZipalignFiles.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBoxZipalignInput.Text = inputZipalignFiles.FileName;
            }
            else if (!radioButtonFileZipalign.Checked && radioButtonFolderZipalign.Checked)
            {
                FolderBrowserDialog inputZipalignFolders = new FolderBrowserDialog();
                if (inputZipalignFolders.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBoxZipalignInput.Text = inputZipalignFolders.SelectedPath;
            }
        }

        private void buttonZipalign_Click(object sender, EventArgs e)
        {
            if (radioButtonFileZipalign.Checked && !radioButtonFolderZipalign.Checked)
                ZipAlign(textBoxZipalignInput.Text);
            else if (!radioButtonFileZipalign.Checked && radioButtonFolderZipalign.Checked)
                ZipalignForking(textBoxZipalignInput.Text);
        }

        private void buttonAAPTPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog aaptDialog = new OpenFileDialog();
            aaptDialog.Multiselect = false;
            aaptDialog.Filter = "aapt.exe|*.exe";

            if (aaptDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxAAPTPath.Text = aaptDialog.FileName;
        }

        private void checkBoxFrameworkPath_CheckStateChanged(object sender, EventArgs e)
        {
            textBoxFramePath.Enabled = checkBoxFrameworkPath.Checked;
            buttonFramePath.Enabled = checkBoxFrameworkPath.Checked;
        }

        private void checkBoxAAPTPath_CheckStateChanged(object sender, EventArgs e)
        {
            textBoxAAPTPath.Enabled = checkBoxAAPTPath.Checked;
            buttonAAPTPath.Enabled = checkBoxAAPTPath.Checked;
        }

        #endregion

        #region UpdateChecker

        private void InitializeUpdateChecker()
        {
            updateCheker = new UpdateChecker("http://infinum.orgfree.com/_Update/APKToolGUI/version.txt", Version.Parse(Application.ProductVersion));
            updateCheker.Completed += new RunWorkerCompletedEventHandler(updateCheker_Completed);
        }

        private void updateCheker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is UpdateChecker.Result)
            {
                UpdateChecker.Result result = (UpdateChecker.Result)e.Result;
                switch (result.State)
                {
                    case UpdateChecker.State.NeedUpdate:
                        if (MessageBox.Show(Language.UpdateNewVersion, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            Process.Start("http://4pda.ru/forum/index.php?showtopic=452034");
                        break;
                    case UpdateChecker.State.NoUpdate:
                        if (!result.Silently)
                            MessageBox.Show(Language.UpdateNoUpdates, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case UpdateChecker.State.Error:
                        if (!result.Silently)
                            MessageBox.Show("Error update checking:" + Environment.NewLine + result.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                Properties.Settings.Default.LastUpdateCheck = DateTime.Now;
            }
        }

        #endregion

        #region Events

        private void processRun_Exception(object sender, Exception e)
        {
            tabControl1.Enabled = true;
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Error, DateTime.Now, e.Message));
            MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void processRun_OutputDataReceived(object sender, ProcessRun.OutData e)
        {
            ToLog(e);
        }

        private void processRun_ErrorDataReceived(object sender, ProcessRun.OutData e)
        {
            ToLog(e);
        }

        private void processRun_Exited(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                tabControl1.Enabled = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }));
            ToStatus(Language.Done, Properties.Resources.done);
        }

        #endregion

        private void SetLanguage()
        {
            String settingsCulture = Properties.Settings.Default.Culture;

            if (settingsCulture.Equals("Auto"))
            {
                Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InstalledUICulture;
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            }
            else
            {
                try
                {
                    System.Globalization.CultureInfo _settingsCulture = System.Globalization.CultureInfo.GetCultureInfo(settingsCulture);
                    Thread.CurrentThread.CurrentUICulture = _settingsCulture;
                    Thread.CurrentThread.CurrentCulture = _settingsCulture;
                }
                catch (Exception exc)
                {
                    Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InstalledUICulture;
                    Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;
                    MessageBox.Show(exc.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetJavaVersion()
        {
            ProcessRun java = new ProcessRun(javaExe);
            List<string> result = null;
            try
            {
                result = java.Run("-version");
            }
            catch (Exception exc)
            {
                ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Error, DateTime.Now, exc.Message));
                return null;
            }

            MatchCollection matches = null;
            foreach (string line in result)
            {
                matches = Regex.Matches(line, "^java version\\s\"(.+)\"$");
                if (matches.Count > 0)
                    return matches[0].Groups[1].Value;
            }

            return null;
        }

        private void ClearLog()
        {
            if (Properties.Settings.Default.ClearLogBeforeAction)
                dataGridView1.Rows.Clear();
        }

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

        #region signapk

        private void InitializeSignApk()
        {
            signApk = new SignApk(javaExe);
            signApk.Exited += new EventHandler(processRun_Exited);
            signApk.OutputDataReceived += new MyDataReceivedEventHandler(processRun_OutputDataReceived);
            signApk.ErrorDataReceived += new MyDataReceivedEventHandler(processRun_ErrorDataReceived);
            signApk.Exception += new ExceptionEventHandler(processRun_Exception);
        }

        private void Singning()
        {
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Signing " + Path.GetFileName(textBox5.Text)));
            signApk.Sign(textBox5.Text, textBox6.Text);
        }

        #endregion

        #region apktool

        private void InitializeAPKTool()
        {
            apkTool = new APKTool(javaExe);
            apkTool.Exited += new EventHandler(processRun_Exited);
            apkTool.OutputDataReceived += new MyDataReceivedEventHandler(processRun_OutputDataReceived);
            apkTool.ErrorDataReceived += new MyDataReceivedEventHandler(processRun_ErrorDataReceived);
            apkTool.Exception += new ExceptionEventHandler(processRun_Exception);
        }

        private void InstallFramework()
        {
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Installing framework " + Path.GetFileName(textBox4.Text)));
            apkTool.InstallFramework(textBox4.Text);
        }

        private void Decompiling()
        {
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Decompiling " + Path.GetFileName(textBox2.Text)));
            apkTool.Decompiling(textBox2.Text,
                Properties.Settings.Default.noSrc,
                Properties.Settings.Default.noRes,
                Properties.Settings.Default.force,
                Properties.Settings.Default.framePathLocation);
        }

        private void Building()
        {
            ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Info, DateTime.Now, "Building " + Path.GetFileName(textBox3.Text)));
            String outputAPK = textBox3.Text + DateTime.Now.ToString("_yyyyMMdd_HH-mm-ss") + ".apk";

            apkTool.Building(textBox3.Text,
                Properties.Settings.Default.buildAll,
                Properties.Settings.Default.AAPTFileLocation,
                outputAPK);
        }

        #endregion

        #region zipalign

        private void InitializeProcessRun()
        {
            zipAlign = new ProcessRun(Application.StartupPath + @"\tools\zipalign.exe");
            zipAlign.OutputDataReceived += new MyDataReceivedEventHandler(processRun_OutputDataReceived);
            zipAlign.ErrorDataReceived += new MyDataReceivedEventHandler(processRun_ErrorDataReceived);
            zipAlign.Exception += new ExceptionEventHandler(processRun_Exception);
            zipAlign.Exited += new EventHandler(processRun_Exited);
        }

        private void ZipAlign(string inputFilePath)
        {
            string outputFile = Path.GetDirectoryName(inputFilePath) + @"\" + Path.GetFileNameWithoutExtension(inputFilePath) + "_zipaligned.apk";

            zipAlign.RunAsync(" -f 4 \"" + inputFilePath + "\" " + "\"" + outputFile + "\"");
        }

        private void ZipalignForking(string folderPath)
        {
            List<string> fileList = new List<string>(Directory.GetFiles(folderPath, "*.apk", SearchOption.TopDirectoryOnly));

            toolStripProgressBar1.Maximum = fileList.Count;
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.Value = 0;

            ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            foreach (String file in fileList)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ZipAlignF), file);
            }
        }

        private void ZipAlignF(Object inputFilePath)
        {
            if (inputFilePath is string)
            {
                string filePath = (string)inputFilePath;
                string outputFile = Path.GetDirectoryName(filePath) + @"\" + Path.GetFileNameWithoutExtension(filePath) + "_zipaligned.apk";

                ProcessRun zipalign = new ProcessRun(Application.StartupPath + @"\tools\zipalign.exe");
                List<string> result = zipalign.Run(" -f 4 \"" + filePath + "\" " + "\"" + outputFile + "\"");

                foreach (string line in result)
                {
                    ToLog(new ProcessRun.OutData(ProcessRun.StreamType.Error, DateTime.Now, line));
                    //ToLog(line);
                }

                BeginInvoke(new MethodInvoker(delegate
                {
                    toolStripProgressBar1.Value++;
                }));
            }
        }

        #endregion

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}