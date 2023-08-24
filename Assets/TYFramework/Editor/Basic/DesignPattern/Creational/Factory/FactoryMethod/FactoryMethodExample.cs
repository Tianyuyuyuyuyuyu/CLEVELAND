using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Factory.FactoryMethod
{
    public class FactoryMethodExample : MonoBehaviour
    {
        void Start()
        {
            var xiaomifatory=new XiaoMiFactroy();
            var xiaomi= xiaomifatory.CreatePhone();
            xiaomi.TurnOn();
    
            var huaweifatory = new XiaoMiFactroy();
            var huawei = huaweifatory.CreatePhone();
            huawei.TurnOn();
        }
    }

    public interface IPhone
    {
        void TurnOn ();
    }

    public class XiaoMiPhone : IPhone
    {
        public void TurnOn()
        {
            Debug.LogError("小米开机logo");
        }
    }

    public class HuaWeiPhone : IPhone
    {
        public void TurnOn()
        {
            Debug.LogError("华为开机logo");
        }
    }

    public interface IFactory
    {
        IPhone CreatePhone();
    }

    public class XiaoMiFactroy : IFactory
    {
        public IPhone CreatePhone()
        {
            return new XiaoMiPhone();
        }
    }

    public class HuaWeiFactroy : IFactory
    {
        public IPhone CreatePhone()
        {
            return new HuaWeiPhone();
        }
    }
}