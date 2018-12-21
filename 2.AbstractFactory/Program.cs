using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace _2.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            Hero voin = new Hero(new VoinFactory());
            foreach (var h in new []{ elf, voin })
            {
                h.Run();
                h.Hit();
            }
            Console.ReadKey();
        }
    }

    #region Wepon

    abstract class Weapon
    {
        public abstract void Hit();
    }

    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Удар мечём");
        }
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Выстрел из арбалета");
        }
    }

    #endregion

    #region Move

    public abstract class Movement
    {
        public abstract void Move();
    }

    public class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Герой бежит");
        }
    }

    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Герой летит");
        }
    }

    #endregion

    #region HeroFactory

    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    class Hero
    {
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Hit()
        {
            weapon.Hit();
        }
    }

    #endregion
}
