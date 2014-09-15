using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace APKToolGUI
{
    class APKTool : ProcessRun
    {
        public APKTool(string javaExe)
            : base(javaExe)
        {
            string executingLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            argumentPrefix = " -jar \"" + executingLocation + @"\tools\apktool.jar" + "\" ";
        }

        private readonly string argumentPrefix;

        public void InstallFramework(String _location)
        {
            if (!base.IsBusy)
            {
                String arguments = argumentPrefix + " if " + "\"" + _location + "\"";

                base.RunAsync(arguments);
            }
        }

        public void Decompiling(String _location, bool noSrc, bool noRes, bool force, String framePath)
        {
            if (!base.IsBusy)
            {
                String apk = "\"" + _location + "\"";
                String arguments = " -o " + "\"" + System.IO.Path.GetDirectoryName(_location) + "\\" + System.IO.Path.GetFileNameWithoutExtension(_location) + "\" ";
                if (noSrc)
                    arguments += " -s ";
                if (noRes)
                    arguments += " -r ";
                if (force)
                    arguments += " -f ";
                if (!String.IsNullOrEmpty(framePath))
                {
                    if (System.IO.Directory.Exists(framePath))
                        arguments += " -p " + "\"" + framePath + "\" ";
                }

                base.RunAsync(argumentPrefix + " d " + arguments + apk);
            }
        }

        public void Building(String _location, bool forceAll, String aaptLocation, String output)
        {
            if (!base.IsBusy)
            {
                String dir = "\"" + _location + "\"";
                String arguments = argumentPrefix + " b ";
                if (forceAll)
                    arguments += " -f ";
                if (!String.IsNullOrEmpty(aaptLocation))
                {
                    if (System.IO.File.Exists(aaptLocation))
                        arguments += " -a \"" + aaptLocation + "\" ";
                }
                if (!String.IsNullOrEmpty(output))
                {
                    //if (System.IO.File.Exists(output))
                    arguments += " -o \"" + output + "\" ";
                }

                base.RunAsync(arguments + dir);
            }
        }

        public string GetVersion()
        {
            if (!base.IsBusy)
            {
                //base.RunAsync(argumentPrefix + "-version");
                List<string> result = null;
                result = base.Run(argumentPrefix + "-version");

                if (result.Count > 0)
                    return result[0];
                else
                    return null;
            }
            else
                return null;
        }

        public static ProcessRun.OutData ParseLog(ProcessRun.OutData inputData)
        {
            MatchCollection mCol = Regex.Matches(inputData.Message, @"^(\w+):\s(.+)$");
            if (mCol.Count > 0)
            {
                switch (mCol[0].Groups[1].Value)
                {
                    case "W":
                        return new OutData(StreamType.Warning, inputData.Time, mCol[0].Groups[2].Value);
                    case "Warning":
                        return new OutData(StreamType.Warning, inputData.Time, mCol[0].Groups[2].Value);
                    case "I":
                        return new OutData(StreamType.Info, inputData.Time, mCol[0].Groups[2].Value);
                    default:
                        return inputData;
                }
            }
            else
                return inputData;
        }
    }
}
