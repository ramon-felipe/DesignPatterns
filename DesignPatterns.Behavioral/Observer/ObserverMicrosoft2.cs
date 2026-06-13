namespace DesignPatterns.Behavioral.Observer;

public sealed record OrderInfo(long Id, decimal Amount);

public sealed class OrderObservable(long id, decimal amount) : IObservable<OrderInfo>
{
    private readonly HashSet<IObserver<OrderInfo>> _observers = [];
    private readonly long _id = id;
    private readonly decimal _amount = amount;

    public IDisposable Subscribe(IObserver<OrderInfo> observer)
    {
        _observers.Add(observer);

        return new Unsubscriber(_observers, observer);
    }

    public void PayOrder()
    {
        var data = new OrderInfo(_id, _amount);

        foreach (var observer in _observers)
        {
            observer.OnNext(data);
        }
    }

    private sealed class Unsubscriber(ISet<IObserver<OrderInfo>> observers, IObserver<OrderInfo> observer) : IDisposable
    {
        private readonly ISet<IObserver<OrderInfo>> _observers = observers;
        private readonly IObserver<OrderInfo> _observer = observer;

        public void Dispose() => _observers?.Remove(_observer);
    }
}

public sealed class MobileAppObserver : IObserver<OrderInfo>
{
    public void OnCompleted() => Console.WriteLine("Order paid");

    public void OnError(Exception error) => Console.WriteLine($"Error occurred: {error.Message}");

    public void OnNext(OrderInfo value) => Console.WriteLine($"[Mobile app observer] Received streaming data: {value.Id} at R$ {value.Amount}");
}

public sealed class EmailObserver : IObserver<OrderInfo>
{
    public void OnCompleted() => Console.WriteLine("Order paid");

    public void OnError(Exception error) => Console.WriteLine($"Error occurred: {error.Message}");

    public void OnNext(OrderInfo value) => Console.WriteLine($"[Email observer] Received streaming data: {value.Id} at R$ {value.Amount}");
}