﻿using Sirenix.OdinInspector.Editor;
using System.Linq;
using UnityEditor;

public class MyTreeEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("My Game/My Tree Editor")]
    private static void OpenWindow()
    {
        GetWindow<MyTreeEditorWindow>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.DefaultMenuStyle = OdinMenuStyle.TreeViewStyle;

        tree.Add("Menu Style", tree.DefaultMenuStyle);

        var allAssets = AssetDatabase.GetAllAssetPaths()
            .Where(x => x.StartsWith("Assets/"))
            .OrderBy(x => x);

        foreach (var path in allAssets)
        {
            tree.AddAssetAtPath(path.Substring("Assets/".Length), path);
        }

        tree.EnumerateTree().AddThumbnailIcons();

        return tree;
    }
}
