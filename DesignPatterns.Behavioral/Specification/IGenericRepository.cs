using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Behavioral.Specification;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Maybe<TEntity> Get(int id);
    IEnumerable<TEntity> GetAll();
}

public class MovieRepository : GenericRepository<Movie>
{
    public MovieRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Movie> GetMovies()
    {
        return base.dbSet.ToList();
    }

    public IEnumerable<Movie> GetMovieWithDirectors()
    {
        return base.dbSet.Include(_ => _.Directors).ToList();
    }
}

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext dbContext;
    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public Maybe<TEntity> Get(int id)
    {
        var entity = this.dbSet.Find(id);

        return entity == null ? Maybe<TEntity>.None : Maybe<TEntity>.From(entity);
    }   

    public IEnumerable<TEntity> GetAll()
    {
        return this.dbSet.AsNoTracking().ToList();
    }
}

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .HasMany(_ => _.Directors)
            .WithMany(_ => _.Movies)
            .UsingEntity<MovieDirector>();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseInMemoryDatabase("database");

        base.OnConfiguring(optionsBuilder);
    }
}

public class DbInitialiser
{
    private readonly AppDbContext dbContext;

    public DbInitialiser(AppDbContext context)
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

        var movieDir1 = new MovieDirector { MovieId = 1, DirectorId = 1 };
        var movieDir2 = new MovieDirector { MovieId = 1, DirectorId = 2 };
        var movieDir3 = new MovieDirector { MovieId = 2, DirectorId = 2 };
        var movieDir4 = new MovieDirector { MovieId = 3, DirectorId = 1 };
        var movieDir5 = new MovieDirector { MovieId = 3, DirectorId = 2 };
        var movieDir6 = new MovieDirector { MovieId = 3, DirectorId = 3 };

        this.dbContext.Set<Movie>().AddRange(movie1, movie2, movie3);
        this.dbContext.Set<Director>().AddRange(dir1, dir2, dir3);
        this.dbContext.Set<MovieDirector>().AddRange(movieDir1, movieDir2, movieDir3, movieDir4, movieDir5, movieDir6);
         this.dbContext.SaveChanges();
    }
}