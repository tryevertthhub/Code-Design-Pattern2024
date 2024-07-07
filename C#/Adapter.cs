using System;
namespace DesignPattern.Adapter.Conceptual
{
    public interface ITarget
    {
        string GetRequest();
    }

    /// <summary>
    /// The adaptee contains some useful behaviour, but its interface is 
    /// incompatable with the existing client code.
    /// </summary>
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    class Adapter: ITarget
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is `{this._adaptee.GetSpecificRequest()}`";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine(target.GetRequest());
        }
    }

}