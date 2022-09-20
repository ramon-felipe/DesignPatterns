using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    /*public class MicrosoftMouse
    {
        public MicrosoftMouse() => Console.WriteLine("Microsoft mouse created!");        
    }*/
    public class MicrosoftMouse : IMouse
    {
        public int ButtonsQty {get;}
        public MicrosoftMouse(int buttonsQty)
        {
            ButtonsQty = buttonsQty;
            Console.WriteLine("Microsoft mouse created!");
        }
    }
}
