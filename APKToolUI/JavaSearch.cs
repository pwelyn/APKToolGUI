using System;
using System.Diagnostics;
using System.IO;

namespace APKToolGUI
{
    class JavaSearch
    {
        public static bool TrySearchJava(ref string defaultJavaExeLocation)
        {
            string newJavaExeLocation = String.Empty;
            if (TryGetPortable(ref newJavaExeLocation))
            {
                defaultJavaExeLocation = newJavaExeLocation;
                return true;
            }
            else if (File.Exists(defaultJavaExeLocation))
                return true;
            else if (TryGetSystemVariable(out newJavaExeLocation))
            {
                defaultJavaExeLocation = newJavaExeLocation;
                return true;
            }
            else if (TryGetSystem(ref newJavaExeLocation))
            {
                defaultJavaExeLocation = newJavaExeLocation;
                return true;
            }
            else
                return false;
        }

        private static bool TryGetPortable(ref string javaExeLocation)
        {
            String javaDir = @"tools\Java";
            if (!Directory.Exists(javaDir))
                return false;
            string[] allFoundFiles = Directory.GetFiles(javaDir, "java.exe", SearchOption.AllDirectories);

            if (allFoundFiles.Length == 1)
            {
                javaExeLocation = allFoundFiles[0];
                return true;
            }
            else
                return false;
        }

        private static bool TryGetSystemVariable(out string javaExeLocation)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("java", "-version ");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                if (!String.IsNullOrEmpty(proc.StandardError.ReadToEnd()))
                {
                    javaExeLocation = "java";
                    return true;
                }
                else
                {
                    javaExeLocation = null;
                    return false;
                }
            }
            catch
            {
                javaExeLocation = null;
                return false;
            }
        }

        private static bool TryGetSystem(ref string javaExeLocation)
        {
            String javaDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Java";
            if (!Directory.Exists(javaDir))
                return false;
            string[] allFoundFiles = Directory.GetFiles(javaDir, "java.exe", SearchOption.AllDirectories);

            if (allFoundFiles.Length == 1)
            {
                javaExeLocation = allFoundFiles[0];
                return true;
            }
            else
                return false;
        }
    }
}
