using DesignPatterns.Creational.AbstractFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public abstract class Laptop : ILaptop
    {
        public Guid SerialNumber { get; private set; }

        public double ScreenSize { get; private set; }

        public BrandEnum Brand { get; private set; }

        public Laptop(BrandEnum brand, double screenSize)
        {
            SerialNumber = Guid.NewGuid();
            ScreenSize = screenSize;
            Brand = brand;
        }
    }
}
