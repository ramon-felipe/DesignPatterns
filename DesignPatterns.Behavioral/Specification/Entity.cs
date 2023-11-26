using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Specification;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}

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

public class Director : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}

public class MovieDirector
{
    public int MovieId { get; set; }
    public int DirectorId { get; set; }
}