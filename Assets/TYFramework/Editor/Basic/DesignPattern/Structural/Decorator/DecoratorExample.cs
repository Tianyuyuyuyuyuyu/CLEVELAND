using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Decorator
{
    public class DecoratorExample : MonoBehaviour
    {
        void Start()
        {
            var applePhone = new ApplePhone();
            
            //想贴膜了
            var applePhoneSticker = new Sticker(applePhone);
            applePhoneSticker.Print();

            //想有挂件了
            var accessories = new Accessories(applePhone);
            accessories.Print();

            //现在我同时有贴膜和手机挂件了
            var sticker = new Sticker(applePhone);
            var accessories1 = new Accessories(sticker);
            accessories1.Print();
        }
    }

    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }
    
    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Debug.LogError("开始执行具体的对象-苹果手机");
        }
    }

    public abstract class Decorator : Phone
    {
        private Phone _phone;

        public Decorator(Phone phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            _phone?.Print();
        }
    }
    
    public class Sticker : Decorator
    {
        public Sticker(Phone phone) : base(phone)
        {
        }

        public override void Print()
        {
            base.Print();

            AddSticker();
        }

        private void AddSticker()
        {
            Debug.LogError("现在苹果手机贴膜了");
        }
    }
    
    public class Accessories : Decorator
    {
        public Accessories(Phone phone) : base(phone)
        {
        }

        public override void Print()
        {
            base.Print();

            AddAccessories();
        }

        private void AddAccessories()
        {
            Debug.LogError("现在苹果手机有漂亮的挂件了");
        }
    }
}
