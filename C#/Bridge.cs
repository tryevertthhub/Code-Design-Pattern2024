using System;
namespace DesignPattern.Bridge.Conceptual
{
    class Abstraction
    {
        protected IImplementation _implementation;
        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }
        public virtual string Operation()
        {
             return "Abstract: Base operation with:\n" + 
                _implementation.OperationImplementation(); 
        }
    }

    class ExtendedAbstraction: Abstraction
    {
        public ExtendedAbstraction(IImplementation implementation): base(implementation)
        {

        }
        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                base._implementation.OperationImplementation();
        }
    }
    public interface IImplementation
    {
        string OperationImplementation();
    }
    class ConcreteImplementationA: IImplementation
    {
        public string OperationImplementation()
        {
             return "ConcreteImplementationA: The result in platform A.\n";
        }

    }
    class ConcreteImplementationB: IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationB: The result in platform B.\n";
        }
    }

    class client
    {
        public void ClientCode(Abstraction abstraction)
        {
            Console.WriteLine(abstraction.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            client client = new client();
            Abstraction abstraction;
            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);
            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }
}