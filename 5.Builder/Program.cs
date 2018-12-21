using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _5.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            Console.ReadKey();
        }
    }

    class Flour
    {
        public string Sort { get; set; }
    }

    class Salt
    {
        
    }

    class Additives
    {
        public string Name { get; set; }
    }

    class Bread
    {
        public Flour Flour { get; set; }
        public Salt Salt { get; set; }
        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }

    abstract class BreadBuilder
    {
        public Bread Bread { get; set; }
        public void CreteBread()
        {
            Bread = new Bread();
        }

        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreteBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour {Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            
        }
    }

    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour(){ Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
            AbstrBuilder builder = new MainBuilder();
            Director dir = new Director(builder);
            dir.Constr();
            Product p = builder.GetRes();
            p.Show();
            Console.ReadKey();
        }
    }

    class Director
    {
        AbstrBuilder builder;

        public Director(AbstrBuilder abstrBuilder)
        {
            this.builder = abstrBuilder;
        }

        public void Constr()
        {
            builder.BuildA();
            builder.BuildB();
            builder.BuildC();
        }
    }

    abstract class AbstrBuilder
    {
        public abstract void BuildA();
        public abstract void BuildB();
        public abstract void BuildC();
        public abstract Product GetRes();
    }

    class Product
    {
        List<object> partsList = new List<object>();

        public void Add(string part)
        {
            partsList.Add(part);
        }

        public void Show()
        {
            foreach (var t in partsList)
            {
                Console.WriteLine(t.ToString());
            }

        }
    }

    class MainBuilder : AbstrBuilder
    {
        Product prod = new Product();

        public override void BuildA()
        {
            prod.Add("Add A");
        }

        public override void BuildB()
        {
            prod.Add("Add B");
        }

        public override void BuildC()
        {
            prod.Add("Add C");
        }

        public override Product GetRes()
        {
            return prod;
        }
    }*/
}