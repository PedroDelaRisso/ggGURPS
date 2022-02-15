using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<GameMaster> GameMasters { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}