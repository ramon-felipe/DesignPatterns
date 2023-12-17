namespace DesignPatterns.Behavioral.Visitor;

public class SalesVisitor : IVisitor
{
    private int BookCount = 0;
    private int VinylCount = 0;

    public void Print()
    {
        Console.WriteLine($"Books sold: {this.BookCount}");
        Console.WriteLine($"Vinyl sold: {this.VinylCount}");
        Console.WriteLine($"The store sold {this.BookCount + this.VinylCount} units today!");
    }

    public void VisitBook(Book book)
    {
        this.BookCount++;
    }

    public void VisitVinyl(Vinyl vinyl)
    {
        this.VinylCount++;
    }
}