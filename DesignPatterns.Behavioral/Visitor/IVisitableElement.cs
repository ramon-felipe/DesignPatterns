namespace DesignPatterns.Behavioral.Visitor;

public interface IVisitableElement
{
    void Accept(IVisitor visitor);
}
