namespace DesignPatterns.Domain;

public class Director : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
