using NSpecifications;

namespace DesignPatterns.Domain;

public class Director : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }

    public static readonly ASpec<Director> Over30YearsOld = new Spec<Director>(_ => _.Age > 30);
    public static ASpec<Director> OverAge(int age) => new Spec<Director>(_ => _.Age > age);
    public static ASpec<Director> HasAtLeastQtyMovies(int moviesQty) => new Spec<Director>(_ => _.Movies.Count >= moviesQty);
    public static ASpec<Director> OverAgeWithAtLeastMoviesQty(int age, int moviesQty) => OverAge(age) & HasAtLeastQtyMovies(moviesQty);
}

public static class DirectorSpecs
{
    public static ASpec<Director> OverAge(int age) => new Spec<Director>(_ => _.Age > age);
    public static ASpec<Director> HasAtLeastQtyMovies(int moviesQty) => new Spec<Director>(_ => _.Movies.Count >= moviesQty);
    public static ASpec<Director> OverAgeWithAtLeastMoviesQty(int age, int moviesQty) => OverAge(age) & HasAtLeastQtyMovies(moviesQty);
}