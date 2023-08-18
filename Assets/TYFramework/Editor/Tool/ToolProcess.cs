using System;
using System.Diagnostics;
using System.Threading;
using UnityEditor;

namespace TYFramework.Editor.Tool
{
    public static class ToolProcess
    {
        [MenuItem("TYFramework/Process/新建记事本", false, 0)]
        public static void OpenNotepad()
        {
            ProcessHead("notepad.exe")
                .SetArguments(@"D:\Users\admin\Desktop\Readme.txt")
                .SetCreateNoWindow(true)
                .SetErrorDialog(true)
                .SetUseShellExecute(true)
                .Start()
                .WaitForExit();
        }

        [MenuItem("TYFramework/Process/查看命令行参数", false, 1)]
        public static void CheckArguments()
        {
            var t = Process.GetProcesses();

            Array.ForEach(t, p =>
            {
                UnityEngine.Debug.LogError(p.ProcessName);
            });
        }

        #region Excute

        public static void ProcessCommand(string command, string argument)
        {
            ProcessHead(command)
                .SetArguments(argument)
                .SetCreateNoWindow(true)
                .SetErrorDialog(true)
                .SetUseShellExecute(true)
                .Start();
        }

        #endregion

        #region Process拓展

        public static ProcessStartInfo ProcessHead()
        {
            return new ProcessStartInfo();
        }

        public static ProcessStartInfo ProcessHead(string command)
        {
            return new ProcessStartInfo(command);
        }

        public static ProcessStartInfo SetFileName(this ProcessStartInfo info, string fileName)
        {
            info.FileName = fileName;

            return info;
        }

        public static ProcessStartInfo SetArguments(this ProcessStartInfo info, string argument)
        {
            info.Arguments = argument;

            return info;
        }

        public static ProcessStartInfo SetCreateNoWindow(this ProcessStartInfo info, bool argument)
        {
            info.CreateNoWindow = argument;
            return info;
        }

        public static ProcessStartInfo SetErrorDialog(this ProcessStartInfo info, bool argument)
        {
            info.ErrorDialog = argument;

            return info;
        }

        public static ProcessStartInfo SetUseShellExecute(this ProcessStartInfo info, bool argument)
        {
            info.UseShellExecute = argument;

            info.RedirectStandardOutput = !argument;
            info.RedirectStandardError = !argument;
            info.RedirectStandardInput = !argument;

            if (!argument)
            {
                info.StandardOutputEncoding = System.Text.Encoding.UTF8;
                info.StandardErrorEncoding = System.Text.Encoding.UTF8;
            }

            return info;
        }

        public static Process Start(this ProcessStartInfo info)
        {
            var process = Process.Start(info);

            if (!info.UseShellExecute)
            {
                UnityEngine.Debug.LogError(process?.StandardOutput);
                UnityEngine.Debug.LogError(process?.StandardError);
            }

            return process;
        }

        /// <summary>
        /// 自动销毁
        /// 延迟等待过程不能交互Unity
        /// </summary>
        /// <param name="process"></param>
        /// <param name="seconds">延时时长(秒)</param>
        public static void WithAutoKill(this Process process, float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));

            process.Kill();
        }

        #endregion
    }

}