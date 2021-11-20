using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<GameMaster> GameMasters { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Advantage> Advantages { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CharacterAdvantage> CharacterAdvantage { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CharacterAdvantage>()
            .HasKey(pk => new { pk.CharacterId, pk.AdvantageId });
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<CharacterAdvantage>()
            .ToTable("TableRelations_CharactersToAdvantages");

        modelBuilder.Entity<Character>()
            .HasMany(left => left.Skills)
            .WithMany(right => right.Characters)
            .UsingEntity(join => join.ToTable("TableRelations_CharactersToSkills"));

        modelBuilder.Entity<Campaign>()
            .HasMany(left => left.Players)
            .WithMany(right => right.Campaigns)
            .UsingEntity(join => join.ToTable("TableRelations_CampaignsToPlayers"));
    }
}