using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DesignPattern.Momento.Conceptual
{
    class Originator
    {
        private string _state;
        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("Originator: My initial state is: " + state);
        }
        public void DoSomething()
        {
             Console.WriteLine("Originator: I'm doing something important.");
             this._state = this.GenerateRandomString(30);
             Console.WriteLine($"Originator: and my state has changed to: {_state}");
        }
        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }
        public IMemento Save()
        {
              return new ConcreteMemento(this._state);
        }
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this._state = memento.GetState();
            Console.Write($"Originator: My state has changed to: {_state}");
        }
    }

    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }
    class ConcreteMemento: IMemento
    {
        private string _state;
        private DateTime _date;
        public ConcreteMemento(string state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }
        public string GetState()
        {
            return this._state;
        }
        public string GetName()
        {
            return $"{this._date} / ({this._state.Substring(0, 9)})...";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }

    class Caretaker
    {
        private List<IMemento> _momentos = new List<IMemento>();
        private Originator _originator = null;
        public Caretaker(Originator originator)
        {
            this._originator = originator;
        }
        public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementos.Add(this._originator.Save());
        }
    }

}