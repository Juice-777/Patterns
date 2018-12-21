using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            School s = new School();
            s.Learn();
            University u = new University();
            u.Learn();

            Console.Read();
        }
    }

    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }

        public abstract void Enter();
        public abstract void Study();

        public virtual void PassExams()
        {
            Console.WriteLine("Сдаём выпускные экзамены");
        }

        public abstract void GetDocument();
    }

    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идём в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }

    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }
    }
}
