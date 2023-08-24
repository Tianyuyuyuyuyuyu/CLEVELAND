using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Adapter.ObjectAdapter
{
    public class ObjectAdapterExample : MonoBehaviour
    {
        void Start()
        {
            TwoHoleTarget twoHoleTarget = new ThreeHoleAdapter();
            twoHoleTarget.Request();
        }
    }

    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标(Target)角色，这里可以写成抽象类或者接口
    /// </summary>
    public class TwoHoleTarget
    {
        public virtual void Request()
        {
            Debug.LogError("两孔的充电器可以使用");
        }
    }

    /// <summary>
    /// 手机充电器是有3个柱子的插头，源角色需要适配的类 (Adaptee)
    /// </summary>
    public class ThreeHoleAdaptee
    {
        public void SpecificRequest()
        {
            Debug.LogError("我是3个插孔的插头也可以使用了");
        }
    }

    /// <summary>
    /// 适配器类，TwoHole这个对象写成接口或者抽象类更好，面向接口编程嘛
    /// </summary>
    public class ThreeHoleAdapter : TwoHoleTarget
    {
        //引用两个孔插头的实例，从而将客户端与TwoHole联系起来
        private ThreeHoleAdaptee _threeHoleAdaptee = new ThreeHoleAdaptee();
        
        //这里可以继续增加适配器对象
        
        public override void Request()
        {
            
            //可以做具体的转换工作
            _threeHoleAdaptee.SpecificRequest();
            //可以做具体的转换工作
        }
    }
}
