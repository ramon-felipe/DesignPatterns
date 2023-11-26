using DesignPatterns.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Infrastructure;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .HasMany(_ => _.Directors)
            .WithMany(_ => _.Movies)
            .UsingEntity<MovieDirectorJoin>();

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
