namespace DesignPatterns.Behavioral.Visitor;

public class Book : Item, IVisitableElement
{
    public Book(int id, double price) : base(id, price) { }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitBook(this);
    }
}
