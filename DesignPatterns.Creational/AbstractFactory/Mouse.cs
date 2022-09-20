using DesignPatterns.Creational.AbstractFactory.Factories;

namespace DesignPatterns.Creational.AbstractFactory
{
    public abstract class Mouse : IMouse
    {
        public Guid SerialNumber { get; private set; }

        public int ButtonsQty { get; private set; }

        public BrandEnum Brand { get; private set; }

        public Mouse(BrandEnum brand, int buttonsQty)
        {
            SerialNumber = Guid.NewGuid();
            ButtonsQty = buttonsQty;
            Brand = brand;
        }
    }
}