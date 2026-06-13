using Newtonsoft.Json;

namespace DesignPatterns.Creational.Prototype;

public interface ICloneable<out T>
{
    /// <summary>
    /// Uses the MemberwiseClone method to create a shallow copy of the current object.
    /// Shallow copy means that the new object will have the same values for its fields, but if any of those fields are reference types (like objects), they will point to the same memory location as the original object. 
    /// Therefore, changes to those reference type fields in either the original or the cloned object will affect both objects.
    /// </summary>
    /// <returns></returns>
    T Clone();

    /// <summary>
    /// Creates a deep copy of the current object. 
    /// A deep copy means that all objects are duplicated, and the new object is completely independent of the original.
    /// </summary>
    /// <returns></returns>
    T DeepClone();
}

public interface IPerson
{
    string Name { get; set; }
}

public class Teacher : IPerson
{
    public string Name { get; set; }
    public Manager Manager { get; private set; }

    public Teacher(string name, Manager manager)
    {
        this.Name = name;
        this.Manager = manager;
    }

    public Teacher(Teacher other)
    {
        this.Name = other.Name;
        this.Manager = new Manager(other.Manager.Name);
    }
}

public class Manager(string name) : IPerson, ICloneable<Manager>
{
    public string Name { get; set; } = name;

    public Manager Clone()
    {
        return (Manager)MemberwiseClone();
    }

    public Manager DeepClone()
    {
        if (this == null)
            throw new ArgumentNullException(this.GetType().Name, "The object to clone cannot be null.");

        var objAsJson = JsonConvert.SerializeObject(this);
        return JsonConvert.DeserializeObject<Manager>(objAsJson)!;
    }
}

public class Employee(string name, Manager manager) : IPerson, ICloneable<Employee>
{
    public string Name { get; set; } = name;
    public Manager Manager { get; } = manager;

    public Employee Clone()
    {
        return (Employee)MemberwiseClone();
    }

    public Employee DeepClone()
    {
        if (this == null)
            throw new ArgumentNullException(this.GetType().Name, "The object to clone cannot be null.");

        var objAsJson = JsonConvert.SerializeObject(this);
        return JsonConvert.DeserializeObject<Employee>(objAsJson)!;
    }

}
