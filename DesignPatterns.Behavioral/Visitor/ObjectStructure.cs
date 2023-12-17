namespace DesignPatterns.Behavioral.Visitor;

public class ObjectStructure
{
    private readonly List<IVisitableElement> _cart;

    public ObjectStructure(List<IVisitableElement> items)
    {
        _cart = items;
    }

    public void RemoveItem(IVisitableElement item)
    {
        this._cart.Remove(item);
    }

    public void ApplyVisitor(IVisitor visitor)
    {
        Console.WriteLine("\n---------Visitor Break");
        foreach (var item in _cart)
        {
            item.Accept(visitor);
        }

        visitor.Print();
    }
}