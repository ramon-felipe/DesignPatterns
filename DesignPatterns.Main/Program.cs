// See https://aka.ms/new-console-template for more information

#region CREATIONAL

#region SINGLETON
/*using DesignPatterns.Creational.Singleton;

Console.WriteLine("..::SINGLETON::..");

var logger1 = Logger.GetInstance();
var logger2 = Logger.GetInstance();

Console.WriteLine("logger1 hashcode: {0}", logger1.GetHashCode());
Console.WriteLine("logger2 hashcode: {0}", logger2.GetHashCode());
Console.WriteLine("logger1 == logger2 ? {0}", logger1.Equals(logger2));*/
#endregion

#region FACTORY METHOD

/*using DesignPatterns.Creational.Factory;

Console.WriteLine("..::FACTORY METHOD::..");

var carFactory = new CarFactory();

var couple = carFactory.Create(CarTypes.Couple);
var sport = carFactory.Create(CarTypes.Sport);*/

#endregion

#region ABSTRACT FACTORY

/*using DesignPatterns.Creational.AbstractFactory.Factories;

Console.WriteLine("..::ABSTRACT FACTORY::..");

var microsoftProductsFactory = new MicrosoftProductsFactory();
var samsungProductsFactory = new SamsungProductsFactory();

var microsoftShoppingProduct = new ShoppingProduct(microsoftProductsFactory);
var samsungShoppingProduct = new ShoppingProduct(samsungProductsFactory);

microsoftShoppingProduct.ShowLaptopInfos();
microsoftShoppingProduct.ShowMouseInfos();

Console.WriteLine();

samsungShoppingProduct.ShowLaptopInfos();
samsungShoppingProduct.ShowMouseInfos();

Console.ReadKey();*/

#endregion

#region BUILDER
/*using DesignPatterns.Creational.Builder;

Console.WriteLine("..::BUILDER::..");

var carBuilder = new CarBuilder();
var carCreator = new CarCreator(carBuilder);

var car1 = carCreator.Build("sport");
var car2 = carCreator.Build("hatchback");

Console.WriteLine(car1.ToString());
Console.WriteLine(car2.ToString());

Console.ReadKey();*/
#endregion

#region PROTOTYPE

/*using DesignPatterns.Creational.Prototype;

Console.WriteLine("..::PROTOTYPE::..");

var manager = new Manager("John");
var cloneManager = manager.Clone();

var employee = new Employee("Joe", cloneManager);
var cloneEmployee = employee.DeepClone();

Console.WriteLine("Manager name: {0}", manager.Name);
Console.WriteLine("Manager clone name: {0}\n", cloneManager.Name);

Console.WriteLine("Employee: {0}, with manager {1}", employee.Name, employee.Manager.Name);
Console.WriteLine("Employee clone: {0}, with manager {1}\n", cloneEmployee.Name, cloneEmployee.Manager.Name);

cloneManager.Name = "Deborah";
Console.WriteLine("Employee: {0}, with manager {1}", employee.Name, employee.Manager.Name);
Console.WriteLine("Employee clone: {0}, with manager {1}\n", cloneEmployee.Name, cloneEmployee.Manager.Name);


Console.WriteLine("Manager hashcode: {0}",manager.GetHashCode());
Console.WriteLine("cloneManager hashcode: {0}", cloneManager.GetHashCode());
Console.WriteLine("employee.Manager hashcode: {0}", employee.Manager.GetHashCode());
Console.WriteLine("cloneEmployee.Manager hashcode: {0}", cloneEmployee.Manager.GetHashCode());

Console.ReadKey();*/

#endregion

#endregion

#region STRUCTURAL
#region DECORATOR

/*using DesignPatterns.Structural.Decorator;

Console.WriteLine("..:: DECORATOR ::..");

// instantiating our services
var cloudMailService = new CloudMailService();
var onPremiseMailService = new OnPremiseMailService();

// using them
cloudMailService.SendMail("Testing cloud mail service...");
onPremiseMailService.SendMail("Testing onPremise mail service...");

*//*var cloudMailStatistcsDecorator = new MailStatisticsDecorator(cloudMailService);
cloudMailStatistcsDecorator.SendMail("Testing Statistics Decorator for Cloud Mail service...");*//*

var onPremiseStatisticsDatabaseDecorator = new MessageDatabaseDecorator(new MailStatisticsDecorator(onPremiseMailService));

onPremiseStatisticsDatabaseDecorator.SendMail("1) Testing DataBase Decorator for onPremise Mail service...");
onPremiseStatisticsDatabaseDecorator.SendMail("2) Testing DataBase Decorator for onPremise Mail service...");
var onPremiseMessages = onPremiseStatisticsDatabaseDecorator.SentMessages;

foreach (var message in onPremiseMessages)
{
    Console.Write($"\t\nMessage sent: {message}");
}


*//*var cloudMailDataBaseDecorator = new MessageDatabaseDecorator(cloudMailService);
cloudMailDataBaseDecorator.SendMail("1) Testing DataBase Decorator for Cloud Mail service...");
cloudMailDataBaseDecorator.SendMail("2) Testing DataBase Decorator for Cloud Mail service...");

var cloudMailDataBaseMessages = cloudMailDataBaseDecorator.SentMessages;

foreach (var message in cloudMailDataBaseMessages)
{
    Console.WriteLine($"\tMessage sent: {message}");
}*//*

Console.ReadKey();*/

/*var onPremiseStatisticsDatabaseDecorator = new MessageDatabaseDecorator(new MailStatisticsDecorator(onPremiseMailService));

onPremiseStatisticsDatabaseDecorator.SendMail("1) Testing DataBase Decorator for onPremise Mail service...");
onPremiseStatisticsDatabaseDecorator.SendMail("2) Testing DataBase Decorator for onPremise Mail service...");
var onPremiseMessages = onPremiseStatisticsDatabaseDecorator.SentMessages;

foreach (var message in onPremiseMessages)
{
    Console.WriteLine($"\tMessage sent: {message}");
}
*/


#endregion

#region ADAPTER
// using DesignPatterns.Structural.Adapter;

// Console.WriteLine("..:: ADAPTER ::..");
/*
ITarget adapter = new EmployeeAdapter();
var employees = adapter.GetEmployess();

foreach (var employee in employees)
{
    Console.WriteLine($"Employee: {employee}");
}*/

/*var externalSystem = new ExternalSystem();
ICityAdapter cityAdapter = new CityAdapter(externalSystem);
var adaptedCity = cityAdapter.GetNewCity();

Console.WriteLine($"City: {adaptedCity}");*/

/*
ICityAdapter cityAdapterClass = new CityAdapterClass();
var adaptedCityClass = cityAdapterClass.GetNewCity();

Console.WriteLine($"City: {adaptedCityClass}");*/

//Console.ReadKey();
#endregion

#region BRIDGE

/*using DesignPatterns.Structural.Bridge;

Console.WriteLine("..:: BRIDGE ::..");

var noDiscount = new NoDiscount();
var studentDiscount = new StudentDiscount();
var seniorDiscount = new SeniorDiscount();

var oneWeekNoDiscountLicense = new NewOneWeekLicense("basic license no discount", noDiscount);
var seniorOneWeekLicense = new NewOneWeekLicense("senior license", seniorDiscount);
var studentOneWeekLicense = new NewOneWeekLicense("student license", studentDiscount);

Console.WriteLine($"App: {oneWeekNoDiscountLicense.AppName}. " +
                  $"Bought on: {oneWeekNoDiscountLicense.PurchaseDate}. " +
                  $"Price: ${oneWeekNoDiscountLicense.GetPrice()} " +
                  $"App expiration: {oneWeekNoDiscountLicense.GetExpirationDate()}");

Console.WriteLine($"App: {seniorOneWeekLicense.AppName}. " +
                  $"Bought on: {seniorOneWeekLicense.PurchaseDate}. " +
                  $"Price: ${seniorOneWeekLicense.GetPrice()} " +
                  $"App expiration: {seniorOneWeekLicense.GetExpirationDate()}");

Console.WriteLine($"App: {studentOneWeekLicense.AppName}. " +
                  $"Bought on: {studentOneWeekLicense.PurchaseDate}. " +
                  $"Price: ${studentOneWeekLicense.GetPrice()} " +
                  $"App expiration: {studentOneWeekLicense.GetExpirationDate()}");

Console.ReadKey();*/


#endregion

#endregion

#region BEHAVIORAL

#region ITERATOR

//using DesignPatterns.Behavioral.GenericIterator;
//using DesignPatterns.Behavioral.Iterator;

//Console.WriteLine("..:: ITERATOR ::..");

//var car = new Car { Name = "Beetle" };
//var car2 = new Car { Name = "BMW" };

//var p1 = new Person { Name = "P1", Age = 31 };
//var p2 = new Person { Name = "P2", Age = 32 };

//var people = new Person[] { p1, p2 };
//var newPeopleIterator = people.AsIterator();

//while (!newPeopleIterator.IsDone)
//{
//    Console.WriteLine(newPeopleIterator.CurrentItem);
//    newPeopleIterator.Next();
//}

//var genericCarCollection = new GenericCollection<Car> { car, car2 };
//var carIterator = genericCarCollection.CreateIterator();

//while (!carIterator.IsDone)
//{
//    Console.WriteLine(carIterator.CurrentItem);
//    carIterator.Next();
//}


//Console.ReadKey();

#endregion

#region SPECIFICATION

//using DesignPatterns.Behavioral.Specification;
//using DesignPatterns.Domain;
//using DesignPatterns.Infrastructure;
//using NSpecifications;
//using System.Linq.Expressions;


//using var db = new AppDbContext();
//var initializer = new DbInitializer(db);
//initializer.Run();

//var directorOlderThan30Spec = new DirectorsOlderThanSpecification(30);
//var dirWithAtLeastOneMovieSpec = new DirectorsWithAtLeastMovieQtySpecification(1);
//var dirOver30WithAtLeastOneMovieSpec = directorOlderThan30Spec & dirWithAtLeastOneMovieSpec;
//var dirLessThan30WithMovieSpec = dirWithAtLeastOneMovieSpec & !directorOlderThan30Spec;
//var genSpec = new GenericSpecification<Movie>(_ => _.Id > 1);

//var directorsRepo = new GenericRepository<Director>(db);
//var moviesRepo = new GenericRepository<Movie>(db);

//var entities = directorsRepo.GetAll();
//var directorsOver30 = directorsRepo.GetAll(directorOlderThan30Spec.ToExpression());
//var dirWithAtLeastOneMovie = directorsRepo.GetAll(dirWithAtLeastOneMovieSpec.ToExpression());
//var dirOver30WithAtLeastOneMovie = directorsRepo.GetAll(dirOver30WithAtLeastOneMovieSpec.ToExpression());
//var dirLessThan30WithMovie = directorsRepo.GetAll(dirLessThan30WithMovieSpec.ToExpression());
//var movies = moviesRepo.GetAll(genSpec.Expression);

//Console.WriteLine("All directors");
//foreach (var director in entities) Console.WriteLine(director);

//Console.WriteLine();
//foreach (var director in entities)
//{
//    if (!directorOlderThan30Spec.IsSatisfiedBy(director))
//        Console.WriteLine($"The director [{director.Name}] is not older than 30y. He has {director.Age}yo.");
//}

//Console.WriteLine("\n*List of directors older than 30yo.*");
//foreach (var director in directorsOver30)
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*List of directors with at least one movie.*");
//foreach (var director in dirWithAtLeastOneMovie)
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*List of directors older than 30yo with at least one movie.*");
//foreach (var director in dirOver30WithAtLeastOneMovie)
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*List of directors with 30yo or less with at least one movie.*");
//foreach (var director in dirLessThan30WithMovie)
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*Movies Test*");
//foreach (var movie in movies)
//{
//    Console.WriteLine(movie);
//}

//// using NSpecification
//var directorsWithAtLeastOneMovie = new Spec<Director>(_ => _.Movies.Count >= 1);
//var directorsOver30Spec = new Spec<Director>(_ => _.Age > 30);

//var directorsOver30WithAtLeastOneMovieSpec = directorsWithAtLeastOneMovie & directorsOver30Spec;
//var directorsOver30WithOneMovie = directorsRepo.GetAll(directorsOver30WithAtLeastOneMovieSpec);

//Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
//foreach (var director in directorsOver30WithOneMovie)
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
//foreach (var director in entities.Where(Director.OverAgeWithAtLeastMoviesQty(30, 1)))
//{
//    Console.WriteLine(director);
//}

//Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
//foreach (var director in entities.Where(DirectorSpecs.OverAgeWithAtLeastMoviesQty(30, 1)))
//{
//    Console.WriteLine(director);
//}

//Console.ReadKey();

#endregion

#region VISITOR

//using DesignPatterns.Behavioral.Visitor;

//var items = new List<IVisitableElement>
//{
//    new Book(1, 11.99),
//    new Book(2, 22.79),
//    new Vinyl(3, 17.99),
//    new Book(4, 9.79),
//};

//var discountVisitor = new DiscountVisitor();
//var salesVisitor = new SalesVisitor();

//foreach (var item in items)
//{
//    item.Accept(discountVisitor);
//    item.Accept(salesVisitor);
//}

//discountVisitor.Print();
//salesVisitor.Print();

//Console.WriteLine();

//// using objectStructure
//var cart = new ObjectStructure(items);
//cart.ApplyVisitor(discountVisitor);
//cart.ApplyVisitor(salesVisitor);


//Console.ReadKey();

#endregion

#region OBSERVER SIMPLE
/*
using DesignPatterns.Behavioral.Observer;

Console.Title = "Observer";

var ticketStockService = new TicketStockService();
var ticketResellerService = new TicketResellerService();
var orderService = new OrderService();

// add two observers
orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);

// notify
orderService.CompleteTicketSale(1, 55);

Console.ReadKey();
*/
#endregion

#region OBSERVER - MICROSOFT
/*
// https://learn.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern

var subject = new BaggageHandler();
var observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
var observer2 = new ArrivalsMonitor("SecurityExit");

subject.BaggageStatus(712, "Detroit", 3);
observer1.Subscribe(subject);

subject.BaggageStatus(712, "Kalamazoo", 3);
subject.BaggageStatus(400, "New York-Kennedy", 1);
subject.BaggageStatus(712, "Detroit", 3);
observer2.Subscribe(subject);

subject.BaggageStatus(511, "San Francisco", 2);
subject.BaggageStatus(712);
observer2.Unsubscribe();

subject.BaggageStatus(400);
subject.LastBaggageClaimed();
*/
#endregion

#region STRATEGY

using DesignPatterns.Behavioral.Strategy;

var calculadorDeImpostos = new CalculadorImpostos();
var orcamento = new Orcamento(100);
var icms = new Icms();
var iss = new Iss();

var impostoIcms = calculadorDeImpostos.Calcula(orcamento, icms);
var impostoIss = calculadorDeImpostos.Calcula(orcamento, iss);

Console.WriteLine($"Imposto ICMS: {impostoIcms}");
Console.WriteLine($"Imposto ISS: {impostoIss}");

Console.ReadKey();

#endregion

#endregion
