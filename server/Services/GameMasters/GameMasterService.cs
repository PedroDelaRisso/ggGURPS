using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ggGURPS.Models.GameMasters;
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
    }
}