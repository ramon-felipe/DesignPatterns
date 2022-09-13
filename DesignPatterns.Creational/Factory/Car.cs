using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public abstract class Car
    {
        public Car()
        {
            Console.WriteLine("Creating a car...");
        }
    }

    public class Couple : Car
    {
        public Couple()
        {
            Console.WriteLine("Couple car created!");
        }
    }

    public class Sport : Car
    {
        public Sport()
        {
            Console.WriteLine("Sport car created!");
        }
    }
}
