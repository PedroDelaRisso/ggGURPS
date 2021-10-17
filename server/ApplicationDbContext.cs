using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<GameMaster> GameMasters { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Roll> Rolls { get; set; }
    public DbSet<Advantage> Advantages { get; set; }
    public DbSet<Disadvantage> Disadvantages { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}