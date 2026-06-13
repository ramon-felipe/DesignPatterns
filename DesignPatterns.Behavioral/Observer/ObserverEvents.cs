namespace DesignPatterns.Behavioral.Observer;

public sealed class OrderPaidEventArgs(long id, decimal amount) : EventArgs
{
    public long Id { get; } = id;
    public decimal Amount { get; } = amount;
}

public sealed class OrderEvent(long id, decimal amount)
{
    public long Id { get; } = id;
    public decimal Amount { get; } = amount;

    public event EventHandler<OrderPaidEventArgs>? OrderPaid;

    public void PayOrder()
    {
        // logic to process the payment (omitted for demo purposes)
        // after processing the payment, we raise the OrderPaid event to notify all subscribers that the order has been paid.
        OnOrderPaid(this, new OrderPaidEventArgs(Id, Amount));
    }

    private void OnOrderPaid(object? sender, OrderPaidEventArgs e)
    {
        Console.WriteLine($"Order with id {e.Id} has been paid with amount {e.Amount}");
        this.OrderPaid?.Invoke(this, new OrderPaidEventArgs(this.Id, this.Amount));
    }
}

public interface IOrderPaidSubscriber
{
    void OnOrderPaid(object? sender, OrderPaidEventArgs e);
}

public sealed class MobileAppSubscriber : IOrderPaidSubscriber
{
    public void OnOrderPaid(object? sender, OrderPaidEventArgs e) =>    
        Console.WriteLine($"Mobile app notification: Order with id {e.Id} has been paid with amount {e.Amount}");    
}

public sealed class EmailSubscriber : IOrderPaidSubscriber
{
    public void OnOrderPaid(object? sender, OrderPaidEventArgs e) =>    
        Console.WriteLine($"Email notification: Order with id {e.Id} has been paid with amount {e.Amount}");    
}