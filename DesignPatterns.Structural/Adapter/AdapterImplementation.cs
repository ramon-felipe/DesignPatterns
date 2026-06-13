using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Adaptee class
    /// 
    /// It simulates a third-party library that provides a method to get a list of employees, but it returns the data in a format (HashSet<string>) that is incompatible with the ITarget interface (which expects a List<string>).
    /// </summary>
    public class ThirdPartyEmployee
    {
        public HashSet<string> GetEmployeeList()
        {
            var employees = new HashSet<string> { "Adam", "Bee", "Carlos", "David" };

            return employees;
        }
    }

    // ITarget interface
    public interface ITarget
    {
        List<string> GetEmployees();
    }

    /// <summary>
    /// This is a class Adapter
    /// 
    /// Adapter class that inherits from the Adaptee and implements the ITarget interface.
    /// The bridge between the incompatible interfaces is made by the GetEmployees method, which calls the GetEmployeeList method of the Adaptee and converts the HashSet<string> to a List<string>.
    /// </summary>
    public class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees() => [.. base.GetEmployeeList()];        
    }

    /// <summary>
    /// This is an object Adapter. It uses composition instead of inheritance to adapt the Adaptee to the ITarget interface (follwing SOLID principles).
    /// See that it does not exposes the GetEmployeeList method of the Adaptee, but only the GetEmployees method of the ITarget interface.
    /// 
    /// Adapter class that inherits from the Adaptee and implements the ITarget interface.
    /// The bridge between the incompatible interfaces is made by the GetEmployees method, which calls the GetEmployeeList method of the Adaptee and converts the HashSet<string> to a List<string>.
    /// </summary>
    public class EmployeeAdapter2(ThirdPartyEmployee thirdPartyEmployee) : ITarget
    {
        private readonly ThirdPartyEmployee _thirdPartyEmployee = thirdPartyEmployee;

        public List<string> GetEmployees() => [.. this._thirdPartyEmployee.GetEmployeeList()];
    }
}
