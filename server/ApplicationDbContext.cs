using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<GameMaster> GameMasters { get; set; }
        public DbSet<AdvantageAndDisadvantage> AdvantagesAndDisadvantages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}