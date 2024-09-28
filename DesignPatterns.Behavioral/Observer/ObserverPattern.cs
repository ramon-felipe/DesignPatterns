namespace DesignPatterns.Behavioral.Observer;

public class TicketChange(int artistId, int amount)
{
    public int Amount { get; set; } = amount;
    public int ArtistId { get; set; } = artistId;

    public override string ToString()
    {
        return $"ArtistId: {this.ArtistId} - Amount: {this.Amount}";
    }
}

/// <summary>
/// Observer
/// </summary>
public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
}

/// <summary>
/// Concrete Observer
/// </summary>
public class TicketResellerService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // update local datastore. (datastore omitted for demo purposes)
        Console.WriteLine($"{this.GetType().Name} notified of ticket change: artist {ticketChange}");
    }
}

public class TicketStockService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // update local datastore. (datastore omitted for demo purposes)
        Console.WriteLine($"{this.GetType().Name} notified of ticket change: artist {ticketChange}");
    }
}

/// <summary>
/// Subject
/// </summary>
public abstract class TicketChangeNotifier
{
    private readonly List<ITicketChangeListener> _observers = new();

    public void AddObserver(ITicketChangeListener observer)
    {
        this._observers.Add(observer);
    }

    public void RemoveObserver(ITicketChangeListener observer)
    {
        this._observers.Remove(observer);
    }

    public void Notify(TicketChange ticketChange)
    {
        foreach (var observer in this._observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

/// <summary>
/// Concrete Subject
/// </summary>
public class OrderService : TicketChangeNotifier
{
    public void CompleteTicketSale(int artistId, int amount)
    {
        // change local datastore. (datastore omitted for demo purposes)
        Console.WriteLine($"{this.GetType().Name} is changing its state.");

        // notify observers
        Console.WriteLine($"{this.GetType().Name} is notifying observers...");
        Notify(new TicketChange(artistId, amount));
    }
}
