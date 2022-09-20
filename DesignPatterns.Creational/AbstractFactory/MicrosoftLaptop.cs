using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class MicrosoftLaptop : Laptop
    {
        public MicrosoftLaptop() : base(BrandEnum.Microsoft, 14.5)
        {
            Console.WriteLine("Microsoft laptop created!");
        }
    }
}
