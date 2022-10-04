namespace DesignPatterns.Creational.Builder
{
    public class Car
    {
        public int DoorsQty { get; }
        public int MaxSpeed { get; }
        public string Color { get; }

        public Car(int doorsQty, int maxSpeed, string color)
        {
            DoorsQty = doorsQty;
            MaxSpeed = maxSpeed;
            Color = color;
        }

        public override string ToString() =>
            $"This is a {Color} car with {DoorsQty} doors that runs up to {MaxSpeed} km/h";
    }

    public interface ICarBuilder
    {
        ICarBuilder SetDoorsQty(int doorsQty);
        ICarBuilder SetMaxSpeed(int maxSpeed);
        ICarBuilder SetColor(string color);
        Car Build();
    }

    public class CarBuilder : ICarBuilder
    {
        public int MaxSpeed { get; set; }
        public int DoorsQty { get; set; }
        public string Color { get; set; } = string.Empty;

        public ICarBuilder SetMaxSpeed(int maxSpeed)
        {
            this.MaxSpeed = maxSpeed;
            return this;
        }

        public ICarBuilder SetDoorsQty(int doorsQty)
        {
            this.DoorsQty = doorsQty;
            return this;
        }

        public ICarBuilder SetColor(string color)
        {
            this.Color = color;            
            return this;
        }

        public Car Build() =>
            new (this.DoorsQty, this.MaxSpeed, this.Color);
    }

    /// <summary>
    /// The Car Creator class creates a car according to a parameter (carType) passed to it
    /// </summary>
    public class CarCreator
    {
        private readonly CarBuilder _carBuilder;
        public CarCreator(CarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
        }

        public Car Build(string carType)
        {
            if(carType == "sport")
                return _carBuilder.SetDoorsQty(2).SetMaxSpeed(300).SetColor("blue").Build();

            return _carBuilder.SetDoorsQty(4).SetMaxSpeed(100).SetColor("red").Build();
        }
    }
}
