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

#region Builder
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

using DesignPatterns.Creational.Prototype;

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

Console.ReadKey();

#endregion


#endregion