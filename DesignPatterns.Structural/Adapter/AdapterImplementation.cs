using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    // Adaptee class
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
        List<string> GetEmployess();
    }

    public class EmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployess()
        {
            return base.GetEmployeeList().ToList();
        }
    }
}
