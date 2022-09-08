// See https://aka.ms/new-console-template for more information
using DesignPatterns.Creational.Singleton;

Console.WriteLine("..::SINGLETON::..");

var logger1 = Logger.GetInstance();
var logger2 = Logger.GetInstance();

Console.WriteLine("logger1 hashcode: {0}", logger1.GetHashCode());
Console.WriteLine("logger2 hashcode: {0}", logger2.GetHashCode());
Console.WriteLine("logger1 == logger2 ? {0}", logger1.Equals(logger2));