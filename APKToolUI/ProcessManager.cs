using System;
using System.Diagnostics;

namespace PythonDev
{
    class ProcessManager
    {
        public delegate void Log(string msg, bool time = true);
        public delegate void ToggleControls(bool toggle);

        private Process process;
        private ProcessStartInfo psi;
        private Log log;
        private ToggleControls toggleControls;

        public string WorkingDirectory
        {
            get { return psi.WorkingDirectory; }
            set { psi.WorkingDirectory = value; }
        }
        public string Arguments
        {
            get { return psi.Arguments; }
            set { psi.Arguments = value; }
        }

        private const string program = "apktool.bat";

        public ProcessManager(Log _log, ToggleControls _toggleControls, string _path, string _args)
        {
            log = _log;
            toggleControls = _toggleControls;

            psi = new ProcessStartInfo();
            psi.WorkingDirectory = _path;
            psi.FileName = program;
            psi.Arguments = _args;
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Start()
        {
            if (IsRunned())
                return;
            try
            {
                toggleControls(false);

                process = new Process();

                process.StartInfo = psi;

                process.OutputDataReceived += new DataReceivedEventHandler(OutputDataReceived);
                process.ErrorDataReceived += new DataReceivedEventHandler(OutputDataReceived);
                process.Exited += new EventHandler(Exited);
                process.EnableRaisingEvents = true;

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                log(String.Format("{0}> {1} {2}", WorkingDirectory, program, Arguments));
            }
            catch (Exception e)
            {
                log(e.ToString());
            }
        }

        public bool Stop()
        {
            if (!IsRunned())
                return false;
            try
            {
                process.Kill();
                process.WaitForExit();
                process.CancelErrorRead();
                process.CancelOutputRead();
                process.Close();
                process = null;
                toggleControls(true);
            }
            catch (Exception e)
            {
                log(e.ToString());
            }
            return true;
        }

        public bool IsRunned()
        {
            return (process != null);
        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                log(e.Data, false);
        }

        void Exited(object sender, EventArgs e)
        {
            try
            {
                process.EnableRaisingEvents = false;
                log("Server exited");
            }
            finally
            {
                process.EnableRaisingEvents = true;
            }

        }
    }
}
