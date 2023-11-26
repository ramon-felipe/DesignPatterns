namespace DesignPatterns.Domain;

public class Movie : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; }

    public virtual ICollection<Director> Directors { get; set; } = new List<Director>();

    public override string ToString()
    {
        return $"{this.Id} - {this.Name}, {this.Duration}";
    }
}
