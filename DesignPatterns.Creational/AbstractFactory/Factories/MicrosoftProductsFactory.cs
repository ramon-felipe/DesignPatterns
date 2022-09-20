using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Factories
{
    public class MicrosoftProductsFactory : IProductsFactory
    {
        public ILaptop CreateLaptopProduct()
            => new MicrosoftLaptop();

        public IMouse CreateMouseProduct()
            => new MicrosoftMouse();
        
    }
}
