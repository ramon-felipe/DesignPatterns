namespace DesignPatterns.Behavioral.Iterator
{
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public override string ToString()
        {
            return $"My name is {Name} and I have {Age} years old.";
        }
    }
}
