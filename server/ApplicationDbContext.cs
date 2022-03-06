using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Item>().ToTable("Items");
        modelBuilder.Entity<Skill>().ToTable("Skills");
        modelBuilder.Entity<Spell>().ToTable("Spells");
        modelBuilder.Entity<CustomRoll>().ToTable("CustomRolls");
    }
}