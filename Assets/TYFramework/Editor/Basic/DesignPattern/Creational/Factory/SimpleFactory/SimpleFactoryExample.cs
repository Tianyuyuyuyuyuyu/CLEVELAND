using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Factory.SimpleFactory
{
    public class SimpleFactoryExample : MonoBehaviour
    {
        void Start()
        {
            var xiaomi=PhoneFactory.GetPhone("XiaoMi");
            xiaomi.TurnOn();
            var huawei=PhoneFactory.GetPhone("HuaWei");
            huawei.TurnOn();
        }
    }

    public class PhoneFactory
    {
        public static IPhone GetPhone(string brand)
        {
            if (brand == "XiaoMi")
            {
                return new XiaoMiPhone();
            }
        
            if (brand == "HuaWei")
            {
                return new HuaWeiPhone();
            }

            return null;
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
}