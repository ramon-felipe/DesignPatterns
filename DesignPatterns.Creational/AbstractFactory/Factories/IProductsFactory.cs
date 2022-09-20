using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Factories
{
    public interface IProductsFactory
    {
        ILaptop CreateLaptopProduct();
        IMouse CreateMouseProduct();
    }

    public interface IProduct
    {
        Guid SerialNumber { get; }
        BrandEnum Brand { get; }

    }

    public interface ILaptop/* : IProduct*/
    {       
        double ScreenSize { get; }
    }

    public interface IMouse/* : IProduct*/
    {
        int ButtonsQty { get; }
    }

    public class ShoppingProduct
    {
        private readonly ILaptop _laptop;
        private readonly IMouse _mouse;

        public ShoppingProduct(IProductsFactory productsFactory)
        {
            _laptop = productsFactory.CreateLaptopProduct();
            _mouse = productsFactory.CreateMouseProduct();
        }
        
        public void ShowLaptopInfos()
        {
            Console.WriteLine("The laptop has a {0}\" screen size.", _laptop.ScreenSize);
            // Console.WriteLine("The {0} laptop has the serial number: {1} and it has a {2}\" screen size.", _laptop.Brand, _laptop.SerialNumber, _laptop.ScreenSize);
        }

        public void ShowMouseInfos()
        {
            Console.WriteLine("The mouse has {0} buttons.", _mouse.ButtonsQty);
            // Console.WriteLine("The {0} mouse has the serial number: {1} and it has {2} buttons.", _mouse.Brand, _mouse.SerialNumber, _mouse.ButtonsQty);
        }
    }

}
