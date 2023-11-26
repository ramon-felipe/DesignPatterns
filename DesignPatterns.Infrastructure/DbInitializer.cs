using DesignPatterns.Domain;

namespace DesignPatterns.Infrastructure;

public class DbInitializer
{
    private readonly AppDbContext dbContext;

    public DbInitializer(AppDbContext context)
    {
        dbContext = context;
    }

    public void Run()
    {
        this.dbContext.Database.EnsureDeleted();
        this.dbContext.Database.EnsureCreated();

        var movie1 = new Movie { Id = 1, Name = "Movie one", Duration = 120 };
        var movie2 = new Movie { Id = 2, Name = "Movie two", Duration = 160 };
        var movie3 = new Movie { Id = 3, Name = "Movie three", Duration = 180 };

        var dir1 = new Director { Id = 1, Age = 30, Name = "Director one" };
        var dir2 = new Director { Id = 2, Age = 31, Name = "Director two" };
        var dir3 = new Director { Id = 3, Age = 32, Name = "Director three" };

        var movieDir1 = new MovieDirectorJoin { MovieId = 1, DirectorId = 1 };
        var movieDir2 = new MovieDirectorJoin { MovieId = 1, DirectorId = 2 };
        var movieDir3 = new MovieDirectorJoin { MovieId = 2, DirectorId = 2 };
        var movieDir4 = new MovieDirectorJoin { MovieId = 3, DirectorId = 1 };
        var movieDir5 = new MovieDirectorJoin { MovieId = 3, DirectorId = 2 };
        var movieDir6 = new MovieDirectorJoin { MovieId = 3, DirectorId = 3 };

        this.dbContext.Set<Movie>().AddRange(movie1, movie2, movie3);
        this.dbContext.Set<Director>().AddRange(dir1, dir2, dir3);
        this.dbContext.Set<MovieDirectorJoin>().AddRange(movieDir1, movieDir2, movieDir3, movieDir4, movieDir5, movieDir6);
        this.dbContext.SaveChanges();
    }
}