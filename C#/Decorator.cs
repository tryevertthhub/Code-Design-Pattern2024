using System;
namespace DesignPattern.Decorator.Conceptual
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    class ConcreteComponent: Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorator: Component
    {
        protected Component _component;
        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string Operation()
        {
            if (this._component !=null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA: Decorator
    {
        public ConcreteDecoratorA(Component comp): base(comp)
        {

        }

        public override string Operation()
        {
             return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    class ConcreteDecoratorB: Decorator
    {
        public ConcreteDecoratorB(Component comp): base(comp)
        {

        }
        public override string Operation()
        {
             return $"ConcreteDecoratorB({base.Operation()})"; 
        }
    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            var simple = new ConcreteComponent();
            client.ClientCode(simple);

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            client.ClientCode(decorator2);
        }
    }
}