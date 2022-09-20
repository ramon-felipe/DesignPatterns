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
            => new MicrosoftLaptop(10.5);
        

        public IMouse CreateMouseProduct()
            => new MicrosoftMouse(2);
        
    }
}
