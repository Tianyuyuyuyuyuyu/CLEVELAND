using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class MyTargetEditorWindow : OdinEditorWindow
{
    [MenuItem("My Game/My Target Editor")]
    private static void OpenWindow()
    {
        GetWindow<MyTargetEditorWindow>().Show();
    }

    protected override void Initialize()
    {
        this.WindowPadding = Vector4.zero;
    }

    protected override object GetTarget()
    {
        return Selection.activeObject;
    }
}
