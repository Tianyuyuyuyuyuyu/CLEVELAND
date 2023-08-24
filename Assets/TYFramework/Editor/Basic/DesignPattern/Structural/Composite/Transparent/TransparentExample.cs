using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Composite.Transparent
{
    public class TransparentExample : MonoBehaviour
    {
        void Start()
        {
            Folder myWord = new Word();
            myWord.Open();
            
            myWord.Add(new SonFolder());//抛出异常
            myWord.Remove(new SonFolder());//抛出异常

            Folder myFolder = new SonFolder();
            myFolder.Open();
            
            myFolder.Add(new SonFolder());
            myFolder.Remove(new SonFolder());
        }
    }

    /// <summary>
    /// 该抽象类就是文件夹抽象接口的定义，该类型就相当于是抽象构件Component类型
    /// </summary>
    public abstract class Folder
    {
        /// <summary>
        /// 增加文件夹或文件
        /// </summary>
        /// <param name="folder"></param>
        public abstract void Add(Folder folder);
        
        /// <summary>
        /// 删除文件夹或者文件
        /// </summary>
        /// <param name="folder"></param>
        public abstract void Remove(Folder folder);
        
        /// <summary>
        /// 打开文件或者文件夹--该操作相当于Component类型的Operation方法
        /// </summary>
        public abstract void Open();
    }

    /// <summary>
    /// 该Word文档类就是叶子构件的定义，该类型就相当于是Leaf类型，不能在包含子对急
    /// </summary>
    public sealed class Word : Folder
    {
        public override void Add(Folder folder)
        {
            throw new System.Exception("Word文档不具有该功能");
        }

        public override void Remove(Folder folder)
        {
            throw new System.Exception("Word文档不具有该功能");
        }

        public override void Open()
        {
            Debug.LogError("打开Word文档，开始进行编辑");
        }
    }
    
    /// <summary>
    /// sonFolder类型就是树枝构件，由于我们使用的是”透明式”，所以Add,Remove都是从Folder类型继承下来的
    /// </summary>
    public class SonFolder : Folder
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
            Debug.LogError("已经打开当前文件夹");
        }
    }
}
