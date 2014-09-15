using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace APKToolGUI
{
    public class ProcessRun
    {
        private Process run;
        private bool hasExited = true;

        //public event DataReceivedEventHandler OutputDataReceived;
        //public event DataReceivedEventHandler ErrorDataReceived;
        public event MyDataReceivedEventHandler OutputDataReceived;
        public event MyDataReceivedEventHandler ErrorDataReceived;
        
        public event ExceptionEventHandler Exception;
        public event EventHandler Exited;



        public ProcessRun(string processExe)
        {
            run = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = processExe, //задаем имя запускного файла
                    UseShellExecute = false, //отключаем использование оболочки, чтобы можно было читать данные вывода
                    RedirectStandardOutput = true, // разрешаем перенаправление данных вывода
                    RedirectStandardError = true, // разрешаем перенаправление данных вывода
                    CreateNoWindow = true //запрещаем создавать окно для запускаемой программы
                },
                EnableRaisingEvents = true
            };

            run.OutputDataReceived += new DataReceivedEventHandler(run_OutputDataReceived);
            run.ErrorDataReceived += new DataReceivedEventHandler(run_ErrorDataReceived);
            run.Exited += new EventHandler(run_Exited);
        }

        #region Events

        private void run_OutputDataReceived(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                OutputDataReceived(this, new OutData(StreamType.Info, DateTime.Now, outLine.Data));
                //OutputDataReceived(this, outLine);
            } 
        }

        private void run_ErrorDataReceived(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                ErrorDataReceived(this, new OutData(StreamType.Error, DateTime.Now, outLine.Data));
                //ErrorDataReceived(this, outLine);
            }
        }

        private void run_Exited(Object sendingProcess, EventArgs outLine)
        {
            try
            {
                run.CancelOutputRead();
                run.CancelErrorRead();
            }
            catch{}
            //run.Refresh();
            hasExited = true;
            if (Exited != null)
                Exited(this, outLine);
        }

        #endregion

        public void RunAsync(String arguments)
        {
            try
            {
                //run.StartInfo.Arguments = " -jar \"" + jarFile + "\" " + arguments;
                run.StartInfo.Arguments = arguments;
                hasExited = false;
                run.Start();

                //начинаем читать стандартный вывод
                run.BeginOutputReadLine();
                run.BeginErrorReadLine();
            }
            catch (Exception error)
            {
                //Exception(this, new ExceptionEventArgs(error));
                Exception(this, error);
            }
        }

        public List<string> Run(String arguments)
        {
            var output = new List<string>();
            try
            {

                run.StartInfo.Arguments = arguments;
                hasExited = false;
                run.Start();

                while (run.StandardOutput.Peek() > -1)
                {
                    output.Add(/*DateTime.Now.ToString("[HH:mm:ss.fff] ") + "[Output] " +*/ run.StandardOutput.ReadLine());
                }

                while (run.StandardError.Peek() > -1)
                {
                    output.Add(/*DateTime.Now.ToString("[HH:mm:ss.fff] ") + "[Error] " +*/ run.StandardError.ReadLine());
                }

                run.WaitForExit();

                hasExited = true;
            }
            catch (Exception error)
            {
                output.Add(error.Message);
                return output;
            }

            return output;
        }

        public void Dispose()
        {
            run.Dispose();
        }

        public bool IsBusy
        {
            get
            {
                return !hasExited;
            }
        }

        public class OutData
        {
            public OutData(StreamType stream, DateTime time, string message)
            {
                this.Stream = stream;
                this.Time = time;
                this.Message = message;
            }
            public StreamType Stream { get; private set; }
            public DateTime Time { get; private set; }
            public string Message { get; private set; }
        }

        public enum StreamType
        {
            Info,
            Error,
            Warning
        }
    }

    public delegate void ExceptionEventHandler(object sender, Exception e);
    public delegate void MyDataReceivedEventHandler(object sender, ProcessRun.OutData e);
}
