using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto = new Car(4, "Mers", new ElectricalMove());
            auto.Move();
            auto = new Car(5, "Mazda", new PetrolMove());
            auto.Move();

            Console.ReadKey();
        }
    }

    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricalMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }

    class Car
    {
        private int passengers { get; set; }
        private string model { get; set; }

        public IMovable Movable { get; set; }

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }

        public void Move()
        {
            Movable.Move();
        }
    }
}
