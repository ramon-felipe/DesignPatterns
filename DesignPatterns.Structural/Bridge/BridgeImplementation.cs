namespace DesignPatterns.Structural.Bridge
{
    // Abstraction
    public abstract class AppLicense
    {
        public string AppName { get; }
        public DateTime PurchaseDate { get; }

        public AppLicense(string appName)
        {
            this.AppName = appName;
            this.PurchaseDate = DateTime.Now;
        }

        public abstract decimal GetPrice();
        public abstract DateTime GetExpirationDate();
    }


    // Refined Abstraction
    public class OneWeekLicense : AppLicense
    {
        public OneWeekLicense(string appName) : base(appName) { }
        public override decimal GetPrice()
            => 5;

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }

    // Refined Abstraction
    public class NoExpirationLicense : AppLicense
    {
        public NoExpirationLicense(string appName) : base(appName) { }
        public override decimal GetPrice()
            => 50;

        public override DateTime GetExpirationDate()
            => DateTime.MaxValue;
    }

    public class SeniorOneWeekLicense : OneWeekLicense
    {
        public SeniorOneWeekLicense(string appName) : base(appName) { }

        public override decimal GetPrice() => 
            base.GetPrice() * 0.95m; // gives 5% of discount
    }

    public class StudentOneWeekLicense : OneWeekLicense
    {
        public StudentOneWeekLicense(string appName) : base(appName) { }

        public override decimal GetPrice() =>
            base.GetPrice() * 0.95m; // gives 5% of discount
    }

    public class SeniorNoExpirationLicense : NoExpirationLicense
    {
        public SeniorNoExpirationLicense(string appName) : base(appName) { }

        public override decimal GetPrice() =>
            base.GetPrice() * 0.90m; // gives 10% of discount
    }

    public class StudentNoExpirationLicense : NoExpirationLicense
    {
        public StudentNoExpirationLicense(string appName) : base(appName) { }

        public override decimal GetPrice() =>
            base.GetPrice() * 0.90m; // gives 10% of discount
    }

    // Implementor
    public abstract class Discount
    {
        public abstract decimal GetDiscount(decimal value);
    }

    public class NoDiscount : Discount
    {
        public override decimal GetDiscount(decimal value) => 0m;        
    }

    public class SeniorDiscount : Discount
    {
        public override decimal GetDiscount(decimal value) => value * .05m;
    }

    public class StudentDiscount : Discount
    {
        public override decimal GetDiscount(decimal value) => value * .10m;
    }

    // Abstraction
    public abstract class NewAppLicense
    {
        public string AppName { get; }
        public DateTime PurchaseDate { get; }
        protected readonly Discount _discount;

        public NewAppLicense(string appName, Discount discount)
        {
            this.AppName = appName;
            this.PurchaseDate = DateTime.Now;
            this._discount = discount;
        }

        public abstract decimal GetPrice();
        public abstract DateTime GetExpirationDate();
    }

    // Refined Abstractions
    public class NewOneWeekLicense : NewAppLicense
    {
        public NewOneWeekLicense(string appName, Discount discount) : base(appName, discount) { }
        public override decimal GetPrice()
        {
            decimal price = 5;
            return price - base._discount.GetDiscount(price);
        }

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }


    public class NewNoExpirationLicense : NewAppLicense
    {
        public NewNoExpirationLicense(string appName, Discount discount) : base(appName, discount) { }
        public override decimal GetPrice()
        {
            decimal price = 50;
            return price - base._discount.GetDiscount(price);
        }

        public override DateTime GetExpirationDate()
            => PurchaseDate.AddDays(7);
    }
}