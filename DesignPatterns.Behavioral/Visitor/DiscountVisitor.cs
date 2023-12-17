namespace DesignPatterns.Behavioral.Visitor;

public class DiscountVisitor : IVisitor
{
    private double _savings;

    public void Print()
    {
        Console.WriteLine($"\nYou saved a total of ${this._savings} on today's order!");
    }

    public void VisitBook(Book book)
    {
        double discount = 0.0;

        if (book.Price < 20.00)
        {
            discount = book.GetDiscount(0.10);
            Console.WriteLine($"Discounted: Book #{book.Id} is now ${book.Price - discount}");
        }
        else
        {
            Console.WriteLine($"Full price: Book #{book.Id} is ${book.Price}");
        }

        this._savings += discount;
    }

    public void VisitVinyl(Vinyl vinyl)
    {
        var discount = vinyl.GetDiscount(0.15);
        Console.WriteLine($"Super savings: Vinyl #{vinyl.Id} is now ${vinyl.Price - discount}");

        this._savings += discount;
    }
}
