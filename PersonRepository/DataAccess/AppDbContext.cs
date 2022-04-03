using Microsoft.EntityFrameworkCore;
using PersonRepository.Model;

namespace PersonRepository.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Teacher> Teachers => this.Set<Teacher>();
    public DbSet<Student> Students => this.Set<Student>();
    public DbSet<Course> Courses => this.Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties(typeof(Enum))
            .HaveConversion<string>()
            .HaveMaxLength(50);
    }
}
