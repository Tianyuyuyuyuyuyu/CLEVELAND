using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Facade
{
    public class FacadeExample : MonoBehaviour
    {
        void Start()
        {
            var facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }

    class SubSystemOne
    {
        public void MethodOne()
        {
            Debug.LogError("子系统方法一");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Debug.LogError("子系统方法二");
        }
    }
    
    class SubSystemThree
    {
        public void MethodThree()
        {
            Debug.LogError("子系统方法三");
        }
    }
    
    class SubSystemFour
    {
        public void MethodFour()
        {
            Debug.LogError("子系统方法四");
        }
    }

    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Debug.LogError("方法组合A");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }
        
        public void MethodB()
        {
            Debug.LogError("方法组合B");
            _one.MethodOne();
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}
