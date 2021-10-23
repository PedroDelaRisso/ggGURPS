using Microsoft.EntityFrameworkCore;
using ggGURPS.Models.Advantages;
using ggGURPS.Models.Campaigns;
using ggGURPS.Models.Characters;
using ggGURPS.Models.GameMasters;
using ggGURPS.Models.Items;
using ggGURPS.Models.Players;
using ggGURPS.Models.Rolls;
using ggGURPS.Models.Skills;

namespace ggGURPS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GameMaster> GameMasters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Roll> Rolls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasMany(left => left.Advantages)
                .WithMany(right => right.Characters)
                .UsingEntity(join => join.ToTable("TableRelations_CharactersToAdvantages"));

            modelBuilder.Entity<Character>()
                .HasMany(left => left.Skills)
                .WithMany(right => right.Characters)
                .UsingEntity(join => join.ToTable("TableRelations_CharactersToSkills"));

            modelBuilder.Entity<Character>()
                .HasMany(left => left.Items)
                .WithMany(right => right.Characters)
                .UsingEntity(join => join.ToTable("TableRelations_CharactersToItems"));

            modelBuilder.Entity<Player>()
                .HasMany(left => left.Campaigns)
                .WithMany(right => right.Players)
                .UsingEntity(join => join.ToTable("TableRelations_PlayersToCampaigns"));
        }
    }
}