namespace TYFramework.Editor.Tool
{
    /// <summary>
    /// 资源管理器工具
    /// 注意：对于目录或者文件路径需要特别注意的，只能使用"\“而不能使用”/"
    /// </summary>
    public static class ToolExplorer
    {
        /// <summary>
        /// 打开资源管理器文件夹
        /// OpenExplorerFolder(@“C:\Windows”)
        /// </summary>
        /// <param name="dirPath"></param>
        public static void OpenExplorerFolder(string dirPath)
        {
#if UNITY_EDITOR

            ToolProcess.ProcessHead()
                .SetFileName("explorer")
                .SetArguments(@"/e /root," + dirPath.Replace("/", "\\"))
                .SetCreateNoWindow(true)
                .SetErrorDialog(true)
                .SetUseShellExecute(true)
                .Start();
#endif
        }

        /// <summary>
        /// 打开资源管理器文件
        /// OpenExplorerFile(@“c:\windows\system32\calc.exe”)
        /// </summary>
        /// <param name="filePath"></param>
        public static void OpenExplorerFile(string filePath)
        {
#if UNITY_EDITOR
            ToolProcess.ProcessHead()
                .SetFileName("explorer")
                .SetArguments(@"/select," + filePath.Replace("/", "\\"))
                .SetCreateNoWindow(true)
                .SetErrorDialog(true)
                .SetUseShellExecute(true)
                .Start();
#endif
        }
    }
}