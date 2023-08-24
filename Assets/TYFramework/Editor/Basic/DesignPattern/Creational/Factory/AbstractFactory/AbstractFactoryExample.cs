using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Factory.AbstractFactory
{
    public class AbstractFactoryExample : MonoBehaviour
    {
        void Start()
        {
            var xiaomifatory = new XiaoMiFactory();
            var xiaomiPhone = xiaomifatory.CreatePhone();
            xiaomiPhone.TurnOn();
            var xiaomiTV = xiaomifatory.CreateTV();
            xiaomiTV.TrunOn();


            var huaweifatory = new XiaoMiFactory();
            var huaweiPhone = huaweifatory.CreatePhone();
            huaweiPhone.TurnOn();
            var huaweiTV = huaweifatory.CreateTV();
            huaweiTV.TrunOn();
        }
    }

    public interface IPhone
    {
        void TurnOn();
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

    public interface ITV
    {
        void TrunOn();
    }


    public class XiaoMiTV : ITV
    {
        public void TrunOn()
        {
            Debug.LogError("小米电视开机logo");
        }
    }

    public class HuaWeiTV : ITV
    {
        public void TrunOn()
        {
            Debug.LogError("华为电视开机logo");
        }
    }


    public interface IFactory
    {
        IPhone CreatePhone();
        ITV CreateTV();
    }

    public class XiaoMiFactory : IFactory
    {
        public IPhone CreatePhone()
        {
            return new XiaoMiPhone();
        }

        public ITV CreateTV()
        {
            return new XiaoMiTV();
        }
    }

    public class HuaWeiFactory : IFactory
    {
        public IPhone CreatePhone()
        {
            return new HuaWeiPhone();
        }

        public ITV CreateTV()
        {
            return new HuaWeiTV();
        }
    }
}