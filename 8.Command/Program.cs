using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            TVOnCommand tvOnCommand = new TVOnCommand(tv);


            Pult pult = new Pult();
            pult.SetCommand(tvOnCommand);
            pult.PressButton();
            pult.PressUndo();

            Console.Read();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class TV
    {
        public void On()
        {
            Console.WriteLine("TV on");
        }

        public void Off()
        {
            Console.WriteLine("TV off");
        }
    }

    class TVOnCommand :  ICommand
    {
        private TV tv;

        public TVOnCommand(TV t)
        {
            tv = t;
        }

        public void Execute()
        {
            tv.On();
        }

        public void Undo()
        {
            tv.Off();
        }
    }

    class Pult
    {
        private ICommand command;

        public Pult(){}

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }

        public void PressUndo()
        {
            command.Undo();
        }
    }
}
