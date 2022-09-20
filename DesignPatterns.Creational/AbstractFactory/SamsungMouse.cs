using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    /*public class SamsungMouse : Mouse
    {
        public SamsungMouse() : base(BrandEnum.Samsung, 3)
        {
            Console.WriteLine("Samsung mouse created!");
        }
    }*/
    public class SamsungMouse : IMouse
    {
        public int ButtonsQty { get; }

        public SamsungMouse(int buttonsQty)
        {
            ButtonsQty = buttonsQty;
            Console.WriteLine("Samsung mouse created!");
        }
    }
}
