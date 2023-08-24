using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Proxy
{
    public class ProxyExample : MonoBehaviour
    {
        void Start()
        {
            var schoolGirl = new SchoolGirl();
            schoolGirl.Name = "Taylor";

            var proxy = new Proxy(schoolGirl);
            proxy.GiveDolls();
            proxy.GiveFlowers();
            proxy.GiveChocolate();
        }
    }

    class SchoolGirl
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    
    class Pursuit: IGiveGift
    {
        private SchoolGirl _mm;

        public Pursuit(SchoolGirl girl)
        {
            _mm = girl;
        }
        
        public void GiveDolls()
        {
            Debug.LogError($"{_mm.Name}送你洋娃娃");
        }

        public void GiveFlowers()
        {
            Debug.LogError($"{_mm.Name}送你花");
        }

        public void GiveChocolate()
        {
            Debug.LogError($"{_mm.Name}送你巧克力");
        }
    }
    
    class Proxy : IGiveGift
    {
        private Pursuit _gg;

        public Proxy(SchoolGirl girl)
        {
            _gg = new Pursuit(girl);
        }
        
        public void GiveDolls()
        {
            _gg.GiveDolls();
        }

        public void GiveFlowers()
        {
            _gg.GiveFlowers();
        }

        public void GiveChocolate()
        {
            _gg.GiveChocolate();
        }
    }
}
