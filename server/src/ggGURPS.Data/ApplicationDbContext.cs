using Microsoft.EntityFrameworkCore;
using ggGURPS.Domain.Models.Advantages;
using ggGURPS.Domain.Models.Campaigns;
using ggGURPS.Domain.Models.Characters;
using ggGURPS.Domain.Models.GameMasters;
using ggGURPS.Domain.Models.Items;
using ggGURPS.Domain.Models.Players;
using ggGURPS.Domain.Models.Rolls;
using ggGURPS.Domain.Models.Skills;

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