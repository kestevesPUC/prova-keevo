using Microsoft.EntityFrameworkCore;
public class KeevoDbContext : DbContext
{
    public KeevoDbContext(DbContextOptions<KeevoDbContext> options) : base(options)
    { }

    public DbSet<Tarefa> tarefa { get; set; }
    public DbSet<Status> status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        base.OnModelCreating(modelBuilder);
    }
}