using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class MicrosoftMouse : Mouse
    {
        public MicrosoftMouse() 
            : base(BrandEnum.Microsoft, 3) => 
            Console.WriteLine("Microsoft mouse created!");
    }
}
