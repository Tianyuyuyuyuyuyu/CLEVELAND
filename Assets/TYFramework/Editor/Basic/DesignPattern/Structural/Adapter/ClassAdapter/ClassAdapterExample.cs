using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Adapter.ClassAdapter
{
    /// <summary>
    /// 类适配器模式
    /// </summary>
    public class ClassAdapterExample : MonoBehaviour
    {
        void Start()
        {
            ITwoHoleTarget change = new ThreeToTwAdapter();
            change.Request();
        }
    }

    public interface ITwoHoleTarget
    {
        void Request();
    }

    public abstract class ThreeHoleAdaptee
    {
        public void SpecificRequest()
        {
            Debug.LogError("我是三个孔的插头");
        }
    }

    public class ThreeToTwAdapter : ThreeHoleAdaptee, ITwoHoleTarget
    {
        public void Request()
        {
            this.SpecificRequest();
        }
    }
}