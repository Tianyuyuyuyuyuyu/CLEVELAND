#define GitControl
using UnityEditor;
using UnityEngine;

namespace TYFramework.Editor.Tool
{
    /// <summary>
    /// 版本控制编辑器工具
    /// </summary>
    public class ToolVersionControl
    {
        #region 右键菜单
        
#if GitControl
        [MenuItem("Assets/Git/Commit", false, 0)]
        public static void Commit()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:commit /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/Git/Push", false, 1)]
        public static void Push()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:push /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/Git/Pull", false, 1)]
        public static void Pull()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:pull /path:" + GetSelection() + " /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/Git/Revert", false, 2)]
        public static void Revert()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:revert /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/Git/Log", false, 51)]
        public static void Log()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:log /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/Git/Blame", false, 52)]
        public static void Blame()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:blame /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/Git/Merge", false, 53)]
        public static void Merge()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:merge /path:" + GetSelection() + " /closeonend:0");
        }
#elif SVNControl
        [MenuItem("Assets/SVN/Commit", false, 0)]
        public static void Commit()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:commit /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/SVN/Update", false, 1)]
        public static void Pull()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:update /path:" + GetSelection() + " /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("Assets/SVN/Revert", false, 2)]
        public static void Revert()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:revert /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/SVN/Log", false, 51)]
        public static void Log()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:log /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/SVN/Blame", false, 52)]
        public static void Blame()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:blame /path:" + GetSelection() + " /closeonend:0");
        }

        [MenuItem("Assets/SVN/Merge", false, 53)]
        public static void Merge()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", "/command:merge /path:" + GetSelection() + " /closeonend:0");
        }
#endif

        #endregion

        #region 工具栏菜单项

#if GitControl

        [MenuItem("TYFramework/Git/CommitAll _F4", false, 0)]
        public static void CommitAll()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:commit /path:" + "Assets*Packages*ProjectSettings" + " /closeonend:0");
        }

        [MenuItem("TYFramework/Git/Fetch _F5", false, 1)]
        public static void Fetch()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:fetch" + " /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("TYFramework/Git/PushAll _F6", false, 1)]
        public static void PushAll()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:push /path:" + Application.dataPath + " /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("TYFramework/Git/PullAll _F7", false, 1)]
        public static void PullAll()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:pull /path:" + Application.dataPath + " /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("TYFramework/Git/Switch _F8", false, 1)]
        public static void Switch()
        {
            ToolProcess.ProcessCommand("TortoiseGitProc.exe", "/command:switch /path:" + Application.dataPath + " /closeonend:0");
        }

#elif SVNControl

        [MenuItem("TYFramework/SVN/Commit _F4", false, 0)]
        public static void CommitAll()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", $"/command:commit /path:{Application.dataPath} /closeonend:0");
        }

        [MenuItem("TYFramework/SVN/Update _F7", false, 1)]
        public static void PullAll()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", $"/command:update /path:{Application.dataPath} /closeonend:0");
            AssetDatabase.Refresh();
        }

        [MenuItem("TYFramework/SVN/Switch _F8", false, 1)]
        public static void Switch()
        {
            ToolProcess.ProcessCommand("TortoiseProc.exe", $"/command:switch /path:{Application.dataPath} /closeonend:0");
        }

#endif

        #endregion

        #region 辅助函数

        /// <summary>
        /// 获取选中路径参数
        /// </summary>
        /// <returns>路径参数</returns>
        public static string GetSelection()
        {
            var path = "Assets";
            var strs = Selection.assetGUIDs;
            if (strs != null)
            {
                path = "\"";
                for (int i = 0; i < strs.Length; i++)
                {
                    if (i != 0)
                        path += "*";
                    path += AssetDatabase.GUIDToAssetPath(strs[i]);
                    if (AssetDatabase.GUIDToAssetPath(strs[i]) != "Assets")
                        path += "*" + AssetDatabase.GUIDToAssetPath(strs[i]) + ".meta";
                }

                path += "\"";
            }

            return path;
        }

        #endregion
    }
}