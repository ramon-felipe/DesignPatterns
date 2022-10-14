using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    public interface ICloneable<T>
    {
        T Clone();
        T DeepClone();
    }

    public abstract class Person
    {
        public abstract string Name { get; set; }
    }

    public class Manager : Person, ICloneable<Manager>
    {
        public Manager(string name)
        {
            Name = name;
        }

        public override string Name { get; set; }

        public Manager Clone()
        {
            return (Manager)MemberwiseClone();
        }

        public Manager DeepClone()
        {
            var objAsJson = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Manager>(objAsJson);
        }
    }

    public class Employee : Person, ICloneable<Employee>
    {
        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override string Name { get; set; }
        public Manager Manager { get; }

        public Employee Clone()
        {
            return (Employee)MemberwiseClone();
        }

        public Employee DeepClone()
        {
            var objAsJson = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Employee>(objAsJson);
        }

    }
}
