using System.Collections.Generic;
using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Creational.Builder.Form1
{
    public class Form1Example : MonoBehaviour
    {
        void Start()
        {
            var director = new Director();
            var builder1 = new ConcreteBuilder1();
            var builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            var p1 = builder1.GetResult();
            p1.Show();
        
            director.Construct(builder2);
            var p2 = builder2.GetResult();
            p2.Show();
        }
    }

    public class Product
    {
        //Product类，由多个部件组成
        private List<string> parts = new List<string>();
    
        //添加产品部件
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Debug.LogError("\n创建产品");
            foreach (var part in parts)
            {
                Debug.LogError(part);
            }
        }
    }

    abstract class Builder
    {
        public abstract void BuilderPartA();
        public abstract void BuilderPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();
        public override void BuilderPartA()
        {
            _product.Add("部件A");
        }

        public override void BuilderPartB()
        {
            _product.Add("部件B");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();
        public override void BuilderPartA()
        {
            _product.Add("部件X");
        }

        public override void BuilderPartB()
        {
            _product.Add("部件Y");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
        }
    }
}