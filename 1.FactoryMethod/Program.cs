using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstrBuilder builder = new PanelBuilder();
            AbstrHouse panelHouse = builder.Build();
            builder = new WoodBuilder();
            AbstrHouse woodHouse = builder.Build();

            Console.ReadLine();
        }
    }

    #region Builder

    public abstract class AbstrBuilder
    {
        public abstract AbstrHouse Build();
    }

    public class PanelBuilder : AbstrBuilder
    {
        public override AbstrHouse Build()
        {
            return new PanelHouse();
        }
    }

    public class WoodBuilder : AbstrBuilder
    {
        public override AbstrHouse Build()
        {
            return new WoodHouse();
        }
    }

    #endregion

    #region House
    public abstract class AbstrHouse
    {

    }

    public class PanelHouse : AbstrHouse
    {
        public PanelHouse()
        {
            Console.WriteLine("Build PanelHouse");
        }
    }

    public class WoodHouse : AbstrHouse
    {
        public WoodHouse()
        {
            Console.WriteLine("Build WoodHouse");
        }

    }

    #endregion
}
