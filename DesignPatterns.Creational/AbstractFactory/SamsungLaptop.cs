using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class SamsungLaptop : Laptop
    {
        public SamsungLaptop() : base(BrandEnum.Samsung, 11.4)
        {
            Console.WriteLine("Samsung laptop created!");
        }
    }
}
