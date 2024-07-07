using System;
using System.Collections.Generic;

namespace DesignPattern.Builder.Conceptual
{
    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilder: IBuilder
    {
        private Product _product = new Product();
        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        public void BuildPartA()
        {
            this._product.Add("PartA");
        }
        public void BuildPartB()
        {
            this._product.Add("PartB");
        }
        public void BuildPartC()
        {
            this._product.Add("PartC");
        }
        public Product GetProduct()
        {
          Product result = this._product;
          this.Reset();
          return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();
        public void Add(string part)
        {
            this._parts.Add(part);
        }
        public string ListParts()
        {
            string str = string.Empty;
            for (int i = 0; i < this._parts.Count; i ++)
            {
                str += this._parts[i] + ",";
            }
            str = str.Remove(str.Length - 2);
            return 'Product parts: ' + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;
        public IBuilder Builder
        {
            set {_builder = value;}
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.BuildPartA();
        }
        
        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildPartA();
            this._builder.BuildPartB();
            this._builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());
        }
    }
}