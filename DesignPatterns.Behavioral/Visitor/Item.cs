using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor;

public class Item
{
    public Item(int id, double price)
    {
        Id = id;
        Price = price;
    }

    public int Id { get; }
    public double Price { get; }


    public double GetDiscount(double discountPercentage)
    {
        return Math.Round(this.Price * discountPercentage, 2);
    }
}
