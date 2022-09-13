using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public interface ICarFactory
    {
        Car Create(CarTypes carType);
    }
}
