using GraphQLCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLCSharp.Data;

public class AnimalDbContext : DbContext
{
    public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

    public DbSet<Animal> Animals { get; set; }
}
