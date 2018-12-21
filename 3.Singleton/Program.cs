using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.os = new OS();
            comp.os.SetOS("OS_One");
            comp.os.SetOS("OS_Over100500");
            Console.ReadKey();
        }
    }

    class Computer
    {
        public OS os;
    }

    class OS
    {
        OS instance;
        string OSName;

        public void SetOS(string nameOS)
        {
            if (instance == null)
            {
                instance = new OS();
                OSName = nameOS;
            }
        }
    }
}
