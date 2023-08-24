using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Prototype
{
    public class PrototypeExample : MonoBehaviour
    {
        void Start()
        {
            var audiCar = new AudiPrototype();

            var audiCarPrototype = audiCar.Clone();
            var audiCarPrototype1 = audiCar.Clone();

            var bmwCarPrototype = new BMWPrototype().Clone();
            var bmwCarPrototype1 = new BMWPrototype().Clone();
            
            audiCarPrototype.CreatCarType();
            audiCarPrototype1.CreatCarType();
            bmwCarPrototype.CreatCarType();
            bmwCarPrototype1.CreatCarType();
        }
    }

    /// <summary>
    /// 原型接口
    /// </summary>
    public interface ICarPrototype
    {
        /// <summary>
        /// 创建汽车类型品牌
        /// </summary>
        void CreatCarType();

        /// <summary>
        /// 克隆生成实例对象
        /// </summary>
        /// <returns></returns>
        ICarPrototype Clone();
    }

    public class AudiPrototype : ICarPrototype
    {
        private static AudiPrototype _Prototype = null;

        static AudiPrototype()
        {
            _Prototype = new AudiPrototype();
            Debug.LogError("静态构造函数构造AudiPrototype");
        }

        public ICarPrototype Clone()
        {
            return
                (AudiPrototype)_Prototype
                    .MemberwiseClone(); //浅拷贝--每次都是一个new AudiPrototype(),母体是一个不能改的且纯净的对象。避开浅拷贝引用类型的问题
            //return (AudiPrototype)this.MemberwiseClone();//浅拷贝：用了this，就不同了，会出现浅拷贝的问题-->方法创建一个浅表副本，具体来说就是创建一个新对象，然后将当前对象的非静态字段复制到该新对象。如果字段是值类型的，则对该字段执行逐位复制。如果字段是引用类型，则复制引用但不复制引用的对象；因此，原始对象及其复本引用同一对象。
        }

        public void CreatCarType()
        {
            GCHandle hander = GCHandle.Alloc(this);
            var pin = GCHandle.ToIntPtr(hander);
            Debug.LogError($"创建奥迪品牌汽车,地址为{pin}");
        }
    }

    public class BMWPrototype : ICarPrototype
    {
        private static BMWPrototype _Prototype = null;

        static BMWPrototype()
        {
            _Prototype = new BMWPrototype();
            Debug.LogError("静态构造函数构造BMWPrototype");
        }

        public ICarPrototype Clone()
        {
            return (ICarPrototype)_Prototype.MemberwiseClone(); //浅拷贝
        }

        public void CreatCarType()
        {
            GCHandle hander = GCHandle.Alloc(this);
            var pin = GCHandle.ToIntPtr(hander);
            Debug.LogError($"创建宝马品牌汽车,地址为{pin}");
        }
    }

    public class GCHandle
    {
        public static GCHandle Alloc(ICarPrototype prototype)
        {
            return new GCHandle();
        }

        public static int ToIntPtr(GCHandle hander)
        {
            return 0;
        }
    }
}
