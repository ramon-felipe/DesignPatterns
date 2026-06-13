namespace DesignPatterns.Creational.Factory
{
    public abstract class Car
    {
        protected Car()
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
