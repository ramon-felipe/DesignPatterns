using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer;

public readonly record struct BaggageInfo(int FlightNumber, string From, int Carousel);

public sealed class BaggageHandler : IObservable<BaggageInfo>
{
    private readonly HashSet<IObserver<BaggageInfo>> _observers = new();
    private readonly HashSet<BaggageInfo> _flights = new();

    public IDisposable Subscribe(IObserver<BaggageInfo> observer)
    {
        // Check whether observer is already registered. If not, add it.
        if (_observers.Add(observer))
        {
            // Provide observer with existing data.
            foreach (BaggageInfo item in _flights)
            {
                observer.OnNext(item);
            }
        }

        return new Unsubscriber<BaggageInfo>(_observers, observer);
    }

    // Called to indicate all baggage is now unloaded.
    public void BaggageStatus(int flightNumber) =>
        BaggageStatus(flightNumber, string.Empty, 0);

    public void BaggageStatus(int flightNumber, string from, int carousel)
    {
        var info = new BaggageInfo(flightNumber, from, carousel);

        // Carousel is assigned, so add new info object to list.
        if (carousel > 0 && _flights.Add(info))
        {
            foreach (IObserver<BaggageInfo> observer in _observers)
            {
                observer.OnNext(info);
            }
        }
        else if (carousel is 0)
        {
            // Baggage claim for flight is done.
            if (_flights.RemoveWhere(flight => flight.FlightNumber == info.FlightNumber) > 0)
            {
                foreach (IObserver<BaggageInfo> observer in _observers)
                {
                    observer.OnNext(info);
                }
            }
        }
    }

    public void LastBaggageClaimed()
    {
        foreach (IObserver<BaggageInfo> observer in _observers)
        {
            observer.OnCompleted();
        }

        _observers.Clear();
    }

    internal sealed class Unsubscriber<BaggageInfo> : IDisposable
    {
        private readonly ISet<IObserver<BaggageInfo>> _observers;
        private readonly IObserver<BaggageInfo> _observer;

        internal Unsubscriber(
            ISet<IObserver<BaggageInfo>> observers,
            IObserver<BaggageInfo> observer) => (_observers, _observer) = (observers, observer);

        public void Dispose() => _observers.Remove(_observer);
    }
}

public class ArrivalsMonitor : IObserver<BaggageInfo>
{
    private readonly string _name;
    private readonly List<string> _flights = new();
    private readonly string _format = "{0,-20} {1,5}  {2, 3}";
    private IDisposable? _cancellation;

    public ArrivalsMonitor(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        _name = name;
    }

    public virtual void Subscribe(BaggageHandler provider) =>
        _cancellation = provider.Subscribe(this);

    public virtual void Unsubscribe()
    {
        _cancellation?.Dispose();
        _flights.Clear();
    }

    public virtual void OnCompleted() => _flights.Clear();

    // No implementation needed: Method is not called by the BaggageHandler class.
    public virtual void OnError(Exception e)
    {
        // No implementation.
    }

    // Update information.
    public virtual void OnNext(BaggageInfo info)
    {
        bool updated = false;

        // Flight has unloaded its baggage; remove from the monitor.
        if (info.Carousel is 0)
        {
            string flightNumber = string.Format("{0,5}", info.FlightNumber);
            for (int index = _flights.Count - 1; index >= 0; index--)
            {
                string flightInfo = _flights[index];
                if (flightInfo.Substring(21, 5).Equals(flightNumber))
                {
                    updated = true;
                    _flights.RemoveAt(index);
                }
            }
        }
        else
        {
            // Add flight if it doesn't exist in the collection.
            string flightInfo = string.Format(_format, info.From, info.FlightNumber, info.Carousel);
            if (_flights.Contains(flightInfo) is false)
            {
                _flights.Add(flightInfo);
                updated = true;
            }
        }

        if (updated)
        {
            _flights.Sort();
            Console.WriteLine($"Arrivals information from {_name}");
            foreach (string flightInfo in _flights)
            {
                Console.WriteLine(flightInfo);
            }

            Console.WriteLine();
        }
    }
}