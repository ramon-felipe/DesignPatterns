﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Factories
{
    public class SamsungProductsFactory : IProductsFactory
    {
        public ILaptop CreateLaptopProduct()
            => new SamsungLaptop();

        public IMouse CreateMouseProduct()
            => new SamsungMouse();        
    }
}
