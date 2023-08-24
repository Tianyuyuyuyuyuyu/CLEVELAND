using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Composite.Safe
{
    public class SafeExample : MonoBehaviour
    {
        void Start()
        {
            Folder myWord = new Word();
            myWord.Open();
            
            Folder myFolder = new NextFolder();
            myFolder.Open();
            
            ////此处要是用增加和制除功能，需要转型的提作，否则不能使用
            ((SonFolder)myFolder).Add(new NextFolder());
            ((SonFolder)myFolder).Remove(new NextFolder());
        }
    }
    
    /// <summary>
    /// 该抽象类就是文件夹抽象接口的定义，该类型就相当于是抽象构件Component类型
    /// 该类型少了容器对象管理子对象的方法的定义，换了地方，在树枝构件也就是SonFolder类型
    /// </summary>
    public abstract class Folder
    {
        //打开文件或者文件夹--该提作相当于Component类型的Operation方法
        public abstract void Open();
    }
    
    /// <summary>
    /// 该Word文档类就是叶子构件的定义，该类型就相当于是Leaf类型，不能在包含子对象
    /// 这类型现在很干净
    /// </summary>
    public sealed class Word : Folder
    {
        public override void Open()
        {
            Debug.LogError("打开Word文档，开始进行编辑");
        }
    }
    
    /// <summary>
    /// sonFolder类型就是树枝构件，现在由于我们使用的是”安全式",所以Add,Remove都是从此处开始定义的
    /// </summary>
    public abstract class SonFolder : Folder
    {
        public abstract void Add(Folder folder);

        public abstract void Remove(Folder folder);

        public override void Open()
        {
            Debug.LogError("已经打开当前文件夹");
        }
    }
    
    /// <summary>
    /// NextFolder类型就是树校构件的实现类
    /// </summary>
    public sealed class NextFolder : SonFolder
    {
        public override void Add(Folder folder)
        {
            throw new System.Exception("文件或者文件夹已经增加成功");
        }

        public override void Remove(Folder folder)
        {
            throw new System.Exception("文件或者文件夹已经删除成功");
        }
        
        public override void Open()
        {
            Debug.LogError("打开Word文档，开始进行编辑");
        }
    }
}
