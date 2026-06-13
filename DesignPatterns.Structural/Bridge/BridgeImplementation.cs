namespace DesignPatterns.Structural.Bridge
{
    // Abstraction
    public abstract class AppLicense
    {
        public string AppName { get; }
        public DateTime PurchaseDate { get; }

        protected AppLicense(string appName)
        {
            this.AppName = appName;
            this.PurchaseDate = DateTime.Now;
        }

        public abstract decimal GetPrice();
        public abstract DateTime GetExpirationDate();
    }


    // Refined Abstraction
    public class OneWeekLicense(string appName) : AppLicense(appName)
    {
        public override decimal GetPrice()
            => 5;

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }

    // Refined Abstraction
    public class NoExpirationLicense(string appName) : AppLicense(appName)
    {
        public override decimal GetPrice()
            => 50;

        public override DateTime GetExpirationDate()
            => DateTime.MaxValue;
    }

    public class SeniorOneWeekLicense(string appName) : OneWeekLicense(appName)
    {
        public override decimal GetPrice() => 
            base.GetPrice() * 0.95m; // gives 5% of discount
    }

    public class StudentOneWeekLicense(string appName) : OneWeekLicense(appName)
    {
        public override decimal GetPrice() =>
            base.GetPrice() * 0.95m; // gives 5% of discount
    }

    public class SeniorNoExpirationLicense(string appName) : NoExpirationLicense(appName)
    {
        public override decimal GetPrice() =>
            base.GetPrice() * 0.90m; // gives 10% of discount
    }

    public class StudentNoExpirationLicense(string appName) : NoExpirationLicense(appName)
    {
        public override decimal GetPrice() =>
            base.GetPrice() * 0.90m; // gives 10% of discount
    }

    // Implementor
    public interface IDiscount
    {
        decimal GetDiscount(decimal value);
    }

    public class NoDiscount : IDiscount
    {
        public decimal GetDiscount(decimal value) => 0m;        
    }

    public class SeniorDiscount : IDiscount
    {
        public decimal GetDiscount(decimal value) => value * .05m;
    }

    public class StudentDiscount : IDiscount
    {
        public decimal GetDiscount(decimal value) => value * .10m;
    }

    // Abstraction
    public abstract class NewAppLicense(string appName, IDiscount discount)
    {
        public string AppName { get; } = appName;
        public DateTime PurchaseDate { get; } = DateTime.Now;
        protected readonly IDiscount _discount = discount;

        public abstract decimal GetPrice();
        public abstract DateTime GetExpirationDate();
    }

    // Refined Abstractions
    public class NewOneWeekLicense(string appName, IDiscount discount) : NewAppLicense(appName, discount)
    {
        public override decimal GetPrice()
        {
            decimal price = 5;
            return price - base._discount.GetDiscount(price);
        }

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }


    public class NewNoExpirationLicense(string appName, IDiscount discount) : NewAppLicense(appName, discount)
    {
        public override decimal GetPrice()
        {
            decimal price = 50;
            return price - base._discount.GetDiscount(price);
        }

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }
}