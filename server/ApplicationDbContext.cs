using Microsoft.EntityFrameworkCore;

namespace server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<GameMaster> GameMasters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}