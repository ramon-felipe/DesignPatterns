// See https://aka.ms/new-console-template for more information
namespace DesignPatterns.Main;

using DesignPatterns.Behavioral.GenericIterator;
using DesignPatterns.Behavioral.Iterator;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Behavioral.Specification;
using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Behavioral.Visitor;
using DesignPatterns.Creational.AbstractFactory.Factories;
using DesignPatterns.Creational.Builder;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Prototype;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Domain;
using DesignPatterns.Infrastructure;
using DesignPatterns.Structural.Adapter;
using DesignPatterns.Structural.Bridge;
using DesignPatterns.Structural.Decorator;
using NSpecifications;

public static class EntryPoint
{
    public static class Creational
    {
        public static void RunSingleton()
        {
            Console.WriteLine("..::SINGLETON::..");
            Console.Title = "Singleton";

            var logger1 = Logger.GetInstance();
            var logger2 = Logger.GetInstance();

            Console.WriteLine("logger1 hashcode: {0}", logger1.GetHashCode());
            Console.WriteLine("logger2 hashcode: {0}", logger2.GetHashCode());
            Console.WriteLine("logger1 == logger2 ? {0}", logger1.Equals(logger2));
        }

        public static void RunFactoryMethod()
        {
            Console.WriteLine("..::FACTORY METHOD::..");
            Console.Title = "Factory Method";

            var carFactory = new CarFactory();
            var couple = carFactory.Create(CarTypes.Couple);
            var sport = carFactory.Create(CarTypes.Sport);
            Console.WriteLine($"Couple car: {couple.GetType().Name}");
            Console.WriteLine($"Sport car: {sport.GetType().Name}");
        }

        public static void RunAbstractFactory()
        {
            Console.WriteLine("..::ABSTRACT FACTORY::..");
            Console.Title = "Abstract Factory";

            var microsoftProductsFactory = new MicrosoftProductsFactory();
            var samsungProductsFactory = new SamsungProductsFactory();
            var microsoftShoppingProduct = new ShoppingProduct(microsoftProductsFactory);
            var samsungShoppingProduct = new ShoppingProduct(samsungProductsFactory);

            microsoftShoppingProduct.ShowLaptopInfos();
            microsoftShoppingProduct.ShowMouseInfos();

            Console.WriteLine();
            samsungShoppingProduct.ShowLaptopInfos();
            samsungShoppingProduct.ShowMouseInfos();
            Console.ReadKey();
        }

        public static void RunBuilder()
        {
            Console.WriteLine("..::BUILDER::..");
            Console.Title = "Builder";

            var carBuilder = new CarBuilder();
            var carCreator = new CarCreator(carBuilder);

            var car1 = carCreator.Build("sport");
            var car2 = carCreator.Build("hatchback");

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            Console.ReadKey();
        }

        public static void RunPrototype()
        {
            Console.WriteLine("..::PROTOTYPE::..");
            Console.Title = "Prototype";

            var manager = new Manager("John");
            var cloneManager = manager.Clone();

            var employee = new Employee("Joe", cloneManager);
            var deepCloneEmployee = employee.DeepClone();
            var shallowCopyEmployee = employee.Clone();

            // Here we use manual copy constructor to create a new teacher instance with the same values as the original teacher, but with a new manager instance.
            var teacher = new Teacher("Teacher1", manager);
            var clonedTeacher = new Teacher(teacher);
            clonedTeacher.Manager.Name = "Cloned Manager";

            Console.WriteLine("Manager name: {0}", manager.Name);
            Console.WriteLine("Manager clone name: {0}\n", cloneManager.Name);

            Console.WriteLine("Employee: {0}, with manager {1}", employee.Name, employee.Manager.Name);
            Console.WriteLine("Employee clone: {0}, with manager {1}\n", deepCloneEmployee.Name, deepCloneEmployee.Manager.Name);

            cloneManager.Name = "Deborah";
            Console.WriteLine("Employee: {0}, with manager {1}", employee.Name, employee.Manager.Name);
            Console.WriteLine("Employee deep clone: {0}, with manager {1}\n", deepCloneEmployee.Name, deepCloneEmployee.Manager.Name);

            Console.WriteLine("Employee: {0}, with manager {1}", employee.Name, employee.Manager.Name);
            Console.WriteLine("Employee shallow copy: {0}, with manager {1}\n", shallowCopyEmployee.Name, shallowCopyEmployee.Manager.Name);

            Console.WriteLine("Changing deep clone employee manager's name to 'Test'");
            deepCloneEmployee.Manager.Name = "Test";

            Console.WriteLine("Showing employee manager's name...");
            Console.WriteLine(employee.Manager.Name);

            Console.WriteLine("Changing shallow copy employee manager's name to 'Test'");
            shallowCopyEmployee.Manager.Name = "Test";

            Console.WriteLine("Showing employee manager's name...");
            Console.WriteLine(employee.Manager.Name);

            Console.ReadKey();
        }
    }

    public static class Structural
    {
        public static void RunDecorator()
        {
            Console.WriteLine("..:: DECORATOR ::..");
            Console.Title = "Decorator";

            // instantiating our services
            var cloudMailService = new CloudMailService();
            var onPremiseMailService = new OnPremiseMailService();

            // using them
            cloudMailService.SendMail("Testing cloud mail service...");
            onPremiseMailService.SendMail("Testing onPremise mail service...");

            var cloudMailStatistcsDecorator = new MailStatisticsDecorator(cloudMailService);
            cloudMailStatistcsDecorator.SendMail("Testing Statistics Decorator for Cloud Mail service...");

            var onPremiseStatisticsDatabaseDecorator = new MessageDatabaseDecorator(new MailStatisticsDecorator(onPremiseMailService));

            onPremiseStatisticsDatabaseDecorator.SendMail("1) Testing DataBase Decorator for onPremise Mail service...");
            onPremiseStatisticsDatabaseDecorator.SendMail("2) Testing DataBase Decorator for onPremise Mail service...");
            var onPremiseMessages = onPremiseStatisticsDatabaseDecorator.SentMessages;

            foreach (var message in onPremiseMessages)
            {
                Console.Write($"\t\nOnPremisse Message sent: {message}");
            }


            var cloudMailDataBaseDecorator = new MessageDatabaseDecorator(cloudMailService);
            cloudMailDataBaseDecorator.SendMail("1) Testing DataBase Decorator for Cloud Mail service...");
            cloudMailDataBaseDecorator.SendMail("2) Testing DataBase Decorator for Cloud Mail service...");

            var cloudMailDataBaseMessages = cloudMailDataBaseDecorator.SentMessages;

            foreach (var message in cloudMailDataBaseMessages)
            {
                Console.WriteLine($"\tCloud Message sent: {message}");
            }

            Console.ReadKey();
        }

        public static void RunAdapter()
        {
            Console.WriteLine("..:: ADAPTER ::..");
            Console.Title = "Adapter";

            var classAdapter = new EmployeeAdapter();
            var objectAdapter = new EmployeeAdapter2(new ThirdPartyEmployee());

            var employees = classAdapter.GetEmployees();
            var employees2 = classAdapter.GetEmployeeList(); // still exposes the incompatible method of the Adaptee, which is not ideal. This is one of the reasons why the object adapter is preferred over the class adapter, as it follows SOLID principles and does not expose the Adaptee's methods.
            var employees3 = objectAdapter.GetEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee}");
            }

            foreach (var employee in employees3)
            {
                Console.WriteLine($"Employee: {employee}");
            }

            // The example below uses object adapter to adapt the CityFromExternalSystem class to the City.
            // It uses composition to adapt the Adaptee to the Target interface, and it does not expose the Adaptee's methods, which is a good practice as it follows SOLID principles.
            var externalSystem = new ExternalSystem();
            var cityAdapter = new CityAdapter(externalSystem);
            var adaptedCity = cityAdapter.GetNewCity();

            Console.WriteLine($"City: {adaptedCity}");


            var cityAdapterClass = new CityAdapterClass();
            var adaptedCityClass = cityAdapterClass.GetNewCity();

            Console.WriteLine($"City: {adaptedCityClass}");

            Console.ReadKey();
        }

        public static void RunBridge()
        {
            Console.WriteLine("..:: BRIDGE ::..");
            Console.Title = "Bridge";

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

            Console.ReadKey();
        }
    }

    public static class Behavioral
    {
        public static void RunIterator()
        {
            Console.WriteLine("..:: ITERATOR ::..");
            Console.Title = "Iterator";

            var car = new DesignPatterns.Behavioral.Iterator.Car { Name = "Beetle" };
            var car2 = new DesignPatterns.Behavioral.Iterator.Car { Name = "BMW" };

            var p1 = new Person { Name = "P1", Age = 31 };
            var p2 = new Person { Name = "P2", Age = 32 };

            var people = new Person[] { p1, p2 };
            var newPeopleIterator = people.AsIterator();

            while (!newPeopleIterator.IsDone)
            {
                Console.WriteLine(newPeopleIterator.CurrentItem);
                newPeopleIterator.Next();
            }

            var genericCarCollection = new GenericCollection<DesignPatterns.Behavioral.Iterator.Car> { car, car2 };
            var carIterator = genericCarCollection.CreateIterator();

            while (!carIterator.IsDone)
            {
                Console.WriteLine(carIterator.CurrentItem);
                carIterator.Next();
            }


            Console.ReadKey();
        }

        public static void RunSpecification()
        {
            Console.WriteLine("..:: SPECIFICATION ::..");
            Console.Title = "Specification";

            using var db = new AppDbContext();
            var initializer = new DbInitializer(db);
            initializer.Run();

            var directorOlderThan30Spec = new DirectorsOlderThanSpecification(30);
            var dirWithAtLeastOneMovieSpec = new DirectorsWithAtLeastMovieQtySpecification(1);
            var dirOver30WithAtLeastOneMovieSpec = directorOlderThan30Spec & dirWithAtLeastOneMovieSpec;
            var dirLessThan30WithMovieSpec = dirWithAtLeastOneMovieSpec & !directorOlderThan30Spec;
            var genSpec = new GenericSpecification<Movie>(_ => _.Id > 1);

            var directorsRepo = new GenericRepository<Director>(db);
            var moviesRepo = new GenericRepository<Movie>(db);

            var entities = directorsRepo.GetAll();
            var directorsOver30 = directorsRepo.GetAll(directorOlderThan30Spec.ToExpression());
            var dirWithAtLeastOneMovie = directorsRepo.GetAll(dirWithAtLeastOneMovieSpec.ToExpression());
            var dirOver30WithAtLeastOneMovie = directorsRepo.GetAll(dirOver30WithAtLeastOneMovieSpec.ToExpression());
            var dirLessThan30WithMovie = directorsRepo.GetAll(dirLessThan30WithMovieSpec.ToExpression());
            var movies = moviesRepo.GetAll(genSpec.Expression);

            Console.WriteLine("All directors");
            foreach (var director in entities) Console.WriteLine(director);

            Console.WriteLine();
            foreach (var director in entities)
            {
                if (!directorOlderThan30Spec.IsSatisfiedBy(director))
                    Console.WriteLine($"The director [{director.Name}] is not older than 30y. He has {director.Age}yo.");
            }

            Console.WriteLine("\n*List of directors older than 30yo.*");
            foreach (var director in directorsOver30)
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*List of directors with at least one movie.*");
            foreach (var director in dirWithAtLeastOneMovie)
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*List of directors older than 30yo with at least one movie.*");
            foreach (var director in dirOver30WithAtLeastOneMovie)
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*List of directors with 30yo or less with at least one movie.*");
            foreach (var director in dirLessThan30WithMovie)
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*Movies Test*");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }

            // using NSpecification
            var directorsWithAtLeastOneMovie = new Spec<Director>(_ => _.Movies.Count >= 1);
            var directorsOver30Spec = new Spec<Director>(_ => _.Age > 30);

            var directorsOver30WithAtLeastOneMovieSpec = directorsWithAtLeastOneMovie & directorsOver30Spec;
            var directorsOver30WithOneMovie = directorsRepo.GetAll(directorsOver30WithAtLeastOneMovieSpec);

            Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
            foreach (var director in directorsOver30WithOneMovie)
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
            foreach (var director in entities.Where(Director.OverAgeWithAtLeastMoviesQty(30, 1)))
            {
                Console.WriteLine(director);
            }

            Console.WriteLine("\n*NSPEC2: List of directors older than 30yo with at least one movie.*");
            foreach (var director in entities.Where(DirectorSpecs.OverAgeWithAtLeastMoviesQty(30, 1)))
            {
                Console.WriteLine(director);
            }

            Console.ReadKey();
        }

        public static void RunVisitor()
        {
            Console.WriteLine("..:: VISITOR ::..");
            Console.Title = "Visitor";

            var items = new List<IVisitableElement>
            {
                new Book(1, 11.99),
                new Book(2, 22.79),
                new Vinyl(3, 17.99),
                new Book(4, 9.79),
            };
            var discountVisitor = new DiscountVisitor();
            var salesVisitor = new SalesVisitor();

            foreach (var item in items)
            {
                item.Accept(discountVisitor);
                item.Accept(salesVisitor);
            }

            discountVisitor.Print();
            salesVisitor.Print();
            Console.WriteLine();

            // using objectStructure
            var cart = new ObjectStructure(items);
            cart.ApplyVisitor(discountVisitor);
            cart.ApplyVisitor(salesVisitor);
            Console.ReadKey();
        }

        public static class Observables
        {
            public static void RunObservableEventsAndDelegates()
            {
                Console.WriteLine("..:: OBSERVABLES WITH EVENTS AND DELEGATES ::..");
                Console.Title = "Observer with Events and Delegates";

                var orderEvent = new OrderEvent(1, 100);
                var mobileAppSubscriber = new MobileAppSubscriber();
                var emailSubscriber = new EmailSubscriber();
                orderEvent.OrderPaid += mobileAppSubscriber.OnOrderPaid;
                orderEvent.OrderPaid += emailSubscriber.OnOrderPaid;
                orderEvent.PayOrder();
                Console.ReadKey();
            }

            public static void RunObservableSimple()
            {
                Console.WriteLine("..:: OBSERVABLE SIMPLE ::..");
                Console.Title = "Observer";

                var ticketStockService = new TicketStockService();
                var ticketResellerService = new TicketResellerService();
                var orderService = new OrderService();

                orderService.AddObserver(ticketStockService);
                orderService.AddObserver(ticketResellerService);

                orderService.CompleteTicketSale(1, 55);

                Console.ReadKey();
            }

            public static void RunObservableMicrosoft()
            {
                Console.WriteLine("..:: OBSERVABLE MICROSOFT ::..");
                Console.Title = "Observer Microsoft";

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
                Console.ReadKey();
            }

            public static void RunObservableMicrosoft2()
            {
                Console.WriteLine("..:: OBSERVABLE MICROSOFT 2 ::..");
                Console.Title = "Observer Microsoft 2";

                var orderObservable = new OrderObservable(1, 100);
                var mobileAppObserver = new MobileAppObserver();
                var emailObserver = new EmailObserver();

                orderObservable.Subscribe(mobileAppObserver);
                orderObservable.Subscribe(emailObserver);
                orderObservable.PayOrder();

                Console.ReadKey();
            }
        }

        public static void RunStrategy()
        {
            Console.WriteLine("..:: STRATEGY ::..");
            Console.Title = "Strategy";

            var taxCalculator = new TaxCalculator();
            var budget = new Budget(100);
            var icms = new Icms();
            var iss = new Iss();
            var taxIcms = taxCalculator.Calculate(budget, icms);
            var taxIss = taxCalculator.Calculate(budget, iss);

            Console.WriteLine($"ICMS Tax: {taxIcms}");
            Console.WriteLine($"ISS Tax: {taxIss}");
            Console.ReadKey();
        }

        public static void RunState()
        {
            Console.WriteLine("..:: STATE ::..");
            Console.Title = "State";

            var budget = new Budget(100);
            budget.Approve();

            var budget2 = new Budget(100);
            budget2.Disapprove();
            budget2.Cancel();
        }
    }
}