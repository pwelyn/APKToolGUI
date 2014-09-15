namespace APKToolGUI
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialogFramework = new System.Windows.Forms.OpenFileDialog();
            this.buttonInstallFramework = new System.Windows.Forms.Button();
            this.buttonBrowseFramework = new System.Windows.Forms.Button();
            this.openFileDialogApk = new System.Windows.Forms.OpenFileDialog();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.folderBrowserDialogBuild = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowseBuild = new System.Windows.Forms.Button();
            this.buttonBrowseDecompile = new System.Windows.Forms.Button();
            this.buttonDecompile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFramePath = new System.Windows.Forms.TextBox();
            this.buttonFramePath = new System.Windows.Forms.Button();
            this.checkBoxFrameworkPath = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAAPTPath = new System.Windows.Forms.TextBox();
            this.buttonAAPTPath = new System.Windows.Forms.Button();
            this.checkBoxAAPTPath = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBoxZipalignInput = new System.Windows.Forms.TextBox();
            this.buttonZipalign = new System.Windows.Forms.Button();
            this.buttonInputZipalign = new System.Windows.Forms.Button();
            this.groupBoxZipalignType = new System.Windows.Forms.GroupBox();
            this.radioButtonFolderZipalign = new System.Windows.Forms.RadioButton();
            this.radioButtonFileZipalign = new System.Windows.Forms.RadioButton();
            this.openFileDialogSignApk = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSignApkOut = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStateImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStateText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBoxZipalignType.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogFramework
            // 
            resources.ApplyResources(this.openFileDialogFramework, "openFileDialogFramework");
            // 
            // buttonInstallFramework
            // 
            resources.ApplyResources(this.buttonInstallFramework, "buttonInstallFramework");
            this.buttonInstallFramework.Name = "buttonInstallFramework";
            this.buttonInstallFramework.UseVisualStyleBackColor = true;
            this.buttonInstallFramework.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonBrowseFramework
            // 
            resources.ApplyResources(this.buttonBrowseFramework, "buttonBrowseFramework");
            this.buttonBrowseFramework.Name = "buttonBrowseFramework";
            this.buttonBrowseFramework.UseVisualStyleBackColor = true;
            this.buttonBrowseFramework.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialogApk
            // 
            resources.ApplyResources(this.openFileDialogApk, "openFileDialogApk");
            // 
            // buttonBuild
            // 
            resources.ApplyResources(this.buttonBuild, "buttonBuild");
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.button6_Click);
            // 
            // folderBrowserDialogBuild
            // 
            this.folderBrowserDialogBuild.ShowNewFolderButton = false;
            // 
            // buttonBrowseBuild
            // 
            resources.ApplyResources(this.buttonBrowseBuild, "buttonBrowseBuild");
            this.buttonBrowseBuild.Name = "buttonBrowseBuild";
            this.buttonBrowseBuild.UseVisualStyleBackColor = true;
            this.buttonBrowseBuild.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonBrowseDecompile
            // 
            resources.ApplyResources(this.buttonBrowseDecompile, "buttonBrowseDecompile");
            this.buttonBrowseDecompile.Name = "buttonBrowseDecompile";
            this.buttonBrowseDecompile.UseVisualStyleBackColor = true;
            this.buttonBrowseDecompile.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonDecompile
            // 
            resources.ApplyResources(this.buttonDecompile, "buttonDecompile");
            this.buttonDecompile.Name = "buttonDecompile";
            this.buttonDecompile.UseVisualStyleBackColor = true;
            this.buttonDecompile.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.textBoxFramePath);
            this.groupBox1.Controls.Add(this.buttonFramePath);
            this.groupBox1.Controls.Add(this.checkBoxFrameworkPath);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.buttonBrowseDecompile);
            this.groupBox1.Controls.Add(this.buttonDecompile);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBoxFramePath
            // 
            resources.ApplyResources(this.textBoxFramePath, "textBoxFramePath");
            this.textBoxFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "framePathLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "framePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFramePath.Enabled = global::APKToolGUI.Properties.Settings.Default.framePath;
            this.textBoxFramePath.Name = "textBoxFramePath";
            this.textBoxFramePath.Text = global::APKToolGUI.Properties.Settings.Default.framePathLocation;
            // 
            // buttonFramePath
            // 
            resources.ApplyResources(this.buttonFramePath, "buttonFramePath");
            this.buttonFramePath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "framePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonFramePath.Enabled = global::APKToolGUI.Properties.Settings.Default.framePath;
            this.buttonFramePath.Name = "buttonFramePath";
            this.buttonFramePath.UseVisualStyleBackColor = true;
            this.buttonFramePath.Click += new System.EventHandler(this.buttonFramePath_Click);
            // 
            // checkBoxFrameworkPath
            // 
            this.checkBoxFrameworkPath.Checked = global::APKToolGUI.Properties.Settings.Default.framePath;
            this.checkBoxFrameworkPath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "framePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBoxFrameworkPath, "checkBoxFrameworkPath");
            this.checkBoxFrameworkPath.Name = "checkBoxFrameworkPath";
            this.checkBoxFrameworkPath.UseVisualStyleBackColor = true;
            this.checkBoxFrameworkPath.CheckStateChanged += new System.EventHandler(this.checkBoxFrameworkPath_CheckStateChanged);
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Checked = global::APKToolGUI.Properties.Settings.Default.force;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "force", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Checked = global::APKToolGUI.Properties.Settings.Default.noRes;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "noRes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::APKToolGUI.Properties.Settings.Default.noSrc;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "noSrc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "decodeFileApkPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Name = "textBox2";
            this.textBox2.Text = global::APKToolGUI.Properties.Settings.Default.decodeFileApkPath;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.textBoxAAPTPath);
            this.groupBox2.Controls.Add(this.buttonAAPTPath);
            this.groupBox2.Controls.Add(this.checkBoxAAPTPath);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.buttonBuild);
            this.groupBox2.Controls.Add(this.buttonBrowseBuild);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // textBoxAAPTPath
            // 
            resources.ApplyResources(this.textBoxAAPTPath, "textBoxAAPTPath");
            this.textBoxAAPTPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "AAPTFileLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAAPTPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "AAPTPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAAPTPath.Enabled = global::APKToolGUI.Properties.Settings.Default.AAPTPath;
            this.textBoxAAPTPath.Name = "textBoxAAPTPath";
            this.textBoxAAPTPath.Text = global::APKToolGUI.Properties.Settings.Default.AAPTFileLocation;
            // 
            // buttonAAPTPath
            // 
            resources.ApplyResources(this.buttonAAPTPath, "buttonAAPTPath");
            this.buttonAAPTPath.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::APKToolGUI.Properties.Settings.Default, "AAPTPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonAAPTPath.Enabled = global::APKToolGUI.Properties.Settings.Default.AAPTPath;
            this.buttonAAPTPath.Name = "buttonAAPTPath";
            this.buttonAAPTPath.UseVisualStyleBackColor = true;
            this.buttonAAPTPath.Click += new System.EventHandler(this.buttonAAPTPath_Click);
            // 
            // checkBoxAAPTPath
            // 
            this.checkBoxAAPTPath.Checked = global::APKToolGUI.Properties.Settings.Default.AAPTPath;
            this.checkBoxAAPTPath.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "AAPTPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.checkBoxAAPTPath, "checkBoxAAPTPath");
            this.checkBoxAAPTPath.Name = "checkBoxAAPTPath";
            this.checkBoxAAPTPath.UseVisualStyleBackColor = true;
            this.checkBoxAAPTPath.CheckStateChanged += new System.EventHandler(this.checkBoxAAPTPath_CheckStateChanged);
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.Checked = global::APKToolGUI.Properties.Settings.Default.buildAll;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::APKToolGUI.Properties.Settings.Default, "buildAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "buildAppPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Name = "textBox3";
            this.textBox3.Text = global::APKToolGUI.Properties.Settings.Default.buildAppPath;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.buttonBrowseFramework);
            this.groupBox3.Controls.Add(this.buttonInstallFramework);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "installFramePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Name = "textBox4";
            this.textBox4.Text = global::APKToolGUI.Properties.Settings.Default.installFramePath;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "SignedFileLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox6.Name = "textBox6";
            this.textBox6.Text = global::APKToolGUI.Properties.Settings.Default.SignedFileLocation;
            // 
            // button9
            // 
            resources.ApplyResources(this.button9, "button9");
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::APKToolGUI.Properties.Settings.Default, "fileForSigningLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox5.Name = "textBox5";
            this.textBox5.Text = global::APKToolGUI.Properties.Settings.Default.fileForSigningLocation;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBoxZipalignType);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Controls.Add(this.textBoxZipalignInput);
            this.groupBox7.Controls.Add(this.buttonZipalign);
            this.groupBox7.Controls.Add(this.buttonInputZipalign);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // textBoxZipalignInput
            // 
            resources.ApplyResources(this.textBoxZipalignInput, "textBoxZipalignInput");
            this.textBoxZipalignInput.Name = "textBoxZipalignInput";
            // 
            // buttonZipalign
            // 
            resources.ApplyResources(this.buttonZipalign, "buttonZipalign");
            this.buttonZipalign.Name = "buttonZipalign";
            this.buttonZipalign.UseVisualStyleBackColor = true;
            this.buttonZipalign.Click += new System.EventHandler(this.buttonZipalign_Click);
            // 
            // buttonInputZipalign
            // 
            resources.ApplyResources(this.buttonInputZipalign, "buttonInputZipalign");
            this.buttonInputZipalign.Name = "buttonInputZipalign";
            this.buttonInputZipalign.UseVisualStyleBackColor = true;
            this.buttonInputZipalign.Click += new System.EventHandler(this.buttonInputZipalign_Click);
            // 
            // groupBoxZipalignType
            // 
            resources.ApplyResources(this.groupBoxZipalignType, "groupBoxZipalignType");
            this.groupBoxZipalignType.Controls.Add(this.radioButtonFolderZipalign);
            this.groupBoxZipalignType.Controls.Add(this.radioButtonFileZipalign);
            this.groupBoxZipalignType.Name = "groupBoxZipalignType";
            this.groupBoxZipalignType.TabStop = false;
            // 
            // radioButtonFolderZipalign
            // 
            resources.ApplyResources(this.radioButtonFolderZipalign, "radioButtonFolderZipalign");
            this.radioButtonFolderZipalign.Name = "radioButtonFolderZipalign";
            this.radioButtonFolderZipalign.UseVisualStyleBackColor = true;
            // 
            // radioButtonFileZipalign
            // 
            resources.ApplyResources(this.radioButtonFileZipalign, "radioButtonFileZipalign");
            this.radioButtonFileZipalign.Checked = true;
            this.radioButtonFileZipalign.Name = "radioButtonFileZipalign";
            this.radioButtonFileZipalign.TabStop = true;
            this.radioButtonFileZipalign.UseVisualStyleBackColor = true;
            // 
            // openFileDialogSignApk
            // 
            resources.ApplyResources(this.openFileDialogSignApk, "openFileDialogSignApk");
            // 
            // saveFileDialogSignApkOut
            // 
            resources.ApplyResources(this.saveFileDialogSignApkOut, "saveFileDialogSignApkOut");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStateImage,
            this.toolStripStatusLabelStateText,
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabelStateImage
            // 
            this.toolStripStatusLabelStateImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatusLabelStateImage.Name = "toolStripStatusLabelStateImage";
            resources.ApplyResources(this.toolStripStatusLabelStateImage, "toolStripStatusLabelStateImage");
            // 
            // toolStripStatusLabelStateText
            // 
            this.toolStripStatusLabelStateText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripStatusLabelStateText, "toolStripStatusLabelStateText");
            this.toolStripStatusLabelStateText.Name = "toolStripStatusLabelStateText";
            this.toolStripStatusLabelStateText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelStateText.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImage,
            this.ColumnTime,
            this.ColumnMessage});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripLog;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 19;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            // 
            // ColumnImage
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnImage.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnImage.Frozen = true;
            resources.ApplyResources(this.ColumnImage, "ColumnImage");
            this.ColumnImage.Name = "ColumnImage";
            this.ColumnImage.ReadOnly = true;
            this.ColumnImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnTime
            // 
            this.ColumnTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTime.Frozen = true;
            resources.ApplyResources(this.ColumnTime, "ColumnTime");
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.ColumnMessage, "ColumnMessage");
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            // 
            // contextMenuStripLog
            // 
            this.contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem});
            this.contextMenuStripLog.Name = "contextMenuStripLog";
            resources.ApplyResources(this.contextMenuStripLog, "contextMenuStripLog");
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            resources.ApplyResources(this.clearLogToolStripMenuItem, "clearLogToolStripMenuItem");
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBoxZipalignType.ResumeLayout(false);
            this.groupBoxZipalignType.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDecompile;
        private System.Windows.Forms.OpenFileDialog openFileDialogFramework;
        private System.Windows.Forms.Button buttonInstallFramework;
        private System.Windows.Forms.Button buttonBrowseFramework;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonBrowseDecompile;
        private System.Windows.Forms.OpenFileDialog openFileDialogApk;
        private System.Windows.Forms.Button buttonBrowseBuild;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogBuild;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.OpenFileDialog openFileDialogSignApk;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSignApkOut;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBoxZipalignType;
        private System.Windows.Forms.RadioButton radioButtonFolderZipalign;
        private System.Windows.Forms.RadioButton radioButtonFileZipalign;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBoxZipalignInput;
        private System.Windows.Forms.Button buttonInputZipalign;
        private System.Windows.Forms.Button buttonZipalign;
        private System.Windows.Forms.CheckBox checkBoxFrameworkPath;
        private System.Windows.Forms.TextBox textBoxFramePath;
        private System.Windows.Forms.Button buttonFramePath;
        private System.Windows.Forms.TextBox textBoxAAPTPath;
        private System.Windows.Forms.Button buttonAAPTPath;
        private System.Windows.Forms.CheckBox checkBoxAAPTPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStateImage;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLog;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
    }
}

