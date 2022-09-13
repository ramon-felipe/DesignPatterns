using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public class CarFactory : ICarFactory
    {
        public Car Create(CarTypes carType)
        {
            return carType switch
            {
                CarTypes.Couple => new Couple(),
                CarTypes.Sport => new Sport(),
                _ => throw new NotImplementedException("It is not possible to create this type of car yet!"),
            };
        }
    }
}
