using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Attributes> Attributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemStats> ItemStats { get; set; }
    public DbSet<CustomRoll> CustomRolls { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Spell> Spells { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}