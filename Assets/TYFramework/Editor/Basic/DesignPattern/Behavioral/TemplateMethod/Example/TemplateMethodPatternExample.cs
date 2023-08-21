using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Behavioral.TemplateMethod.Example
{

    public class TemplateMethodPatternExample : MonoBehaviour
    {
        void Start()
        {
            Hoagie cust12Hoagie = new ItalienHoagie();
            cust12Hoagie.MakeSandwich();

            Hoagie cust13Hoagie = new VeggieHoagie();
            cust13Hoagie.MakeSandwich();
        }
    }

    public abstract class Hoagie
    {
        public void MakeSandwich()
        {
            Debug.Log("Making new Sandwich");

            CutBun();

            if (CustomerWantsMeat())
            {
                AddMeat();
            }

            if (CustomerWantsCheese())
            {
                AddCheese();
            }

            if (CustomerWantsVegetables())
            {
                AddVegetables();
            }

            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }

            WrapTheHoagie();
        }
        protected abstract void AddMeat();
        protected abstract void AddCheese();
        protected abstract void AddVegetables();
        protected abstract void AddCondiments();

        protected virtual bool CustomerWantsMeat() { return true; } // << called Hook
        protected virtual bool CustomerWantsCheese() { return true; }
        protected virtual bool CustomerWantsVegetables() { return true; }
        protected virtual bool CustomerWantsCondiments() { return true; }

        protected void CutBun()
        {
            Debug.Log("Bun is Cut");
        }

        protected void WrapTheHoagie()
        {
            Debug.Log("Hoagie is wrapped.");
        }
    }


    public class ItalienHoagie : Hoagie
    {
        protected override void AddMeat()
        {
            Debug.Log("Adding the Meat: Salami");
        }

        protected override void AddCheese()
        {
            Debug.Log("Adding the Cheese: Provolone");
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }
    }



    public class VeggieHoagie : Hoagie
    {
        protected override void AddMeat()
        {
        }

        protected override void AddCheese()
        {
        }

        protected override void AddVegetables()
        {
            Debug.Log("Adding the Vegetables: Tomatoes");
        }

        protected override void AddCondiments()
        {
            Debug.Log("Adding the Condiments: Vinegar");
        }

        protected override bool CustomerWantsMeat() { return false; }
        protected override bool CustomerWantsCheese() { return false; }

    }
}