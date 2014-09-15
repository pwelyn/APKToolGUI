using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APKToolGUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (arg.Length > 0)
            {
                switch (arg[0])
                {
                    case "ccm":
                        ExplorerContextMenuMethod(APKToolGUI.ExplorerContextMenu.Action.Create);
                        break;
                    case "rcm":
                        ExplorerContextMenuMethod(APKToolGUI.ExplorerContextMenu.Action.Remove);
                        break;
                    default:
                        if (FilesCheck() == true)
                            Application.Run(new FormExecution(arg));
                        break;
                }
            }
            else
                if (FilesCheck() == true)
                    Application.Run(new FormMain());
        }

        private static bool FilesCheck()
        {
            // проверка файлов
            List<String> missigFiles = MissingFilesCheck();
            if (missigFiles.Count > 0)
            {
                String files = Environment.NewLine;
                foreach (String file in missigFiles)
                {
                    files += @"\tools\" + file + Environment.NewLine;
                }
                MessageBox.Show("Отсутствуют необходимые файлы:" + files, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                return false;
            }
            else
                return true;
        }

        private static List<String> MissingFilesCheck()
        {
            List<String> missingFiles = new List<string>();
            String prePath = Application.StartupPath + @"\tools\";
            String[] fileList = new String[]{
                prePath + "apktool.jar",
                //prePath + "aapt.exe",
                prePath + "signapk.jar",
                prePath + "testkey.x509.pem",
                prePath + "testkey.pk8"};
            for (int i = 0; i < fileList.Length; i++)
                if (!System.IO.File.Exists(fileList[i]))
                    missingFiles.Add(System.IO.Path.GetFileName(fileList[i]));
            return missingFiles;
        }

        private static void ExplorerContextMenuMethod(ExplorerContextMenu.Action action)
        {
            ExplorerContextMenu.Status status = null;

            switch (action)
            {
                case ExplorerContextMenu.Action.Create:
                    status = ExplorerContextMenu.Create();
                    break;
                case ExplorerContextMenu.Action.Remove:
                    status = ExplorerContextMenu.Remove();
                    break;
                default:
                    return;
            }

            if (status.Result)
                MessageBox.Show(status.Message, Application.ProductName);
            else
                MessageBox.Show(status.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
