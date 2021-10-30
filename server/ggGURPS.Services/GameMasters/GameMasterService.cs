using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ggGURPS.Models.GameMasters;
using ggGURPS.DTOs.GameMasters;
using ggGURPS.Data;

namespace ggGURPS.Services.GameMasters
{
    public class GameMasterService : IGameMasterService
    {
        private readonly ApplicationDbContext _context;
        
        public GameMasterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GameMaster> GetById(long id)
        {
            var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);
            return gameMaster;
        }

        public async Task Create(PostGameMasterDTO gameMaster)
        {
            GameMaster gm = new GameMaster(gameMaster.Id, gameMaster.Name);
            _context.GameMasters.Add(gm);
            await this.Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}