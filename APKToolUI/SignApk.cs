using System;
using System.IO;

namespace APKToolGUI
{
    class SignApk : ProcessRun
    {
        public SignApk(string javaExe)
            : base(javaExe)
        {
            executingLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            argumentPrefix = " -jar \"" + executingLocation + @"\tools\signapk.jar" + "\" ";
        }

        private string executingLocation;
        private string argumentPrefix;

        public void Sign(string apkFile, string outputJar)
        {
            if (!base.IsBusy)
            {
                string publicKeyDestination = " \"" + executingLocation + @"\tools\testkey.x509.pem" + "\" ";
                string privateKeyDestination = "\"" + executingLocation + @"\tools\testkey.pk8" + "\" ";
                string inputJar = "\"" + apkFile + "\" ";
                if (String.IsNullOrEmpty(outputJar))
                    outputJar = "\"" + Path.GetDirectoryName(apkFile) + "\\" + Path.GetFileNameWithoutExtension(apkFile) + "_signed" + Path.GetExtension(apkFile) + "\"";
                else
                    outputJar = "\"" + outputJar + "\"";
                base.RunAsync(argumentPrefix + publicKeyDestination + privateKeyDestination + inputJar + outputJar);
            }
        }
    }
}
