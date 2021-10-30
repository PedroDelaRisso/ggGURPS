using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ggGURPS.Models.GameMasters;
using ggGURPS.DTOs.GameMasters;
using ggGURPS.Data;
using System;

namespace ggGURPS.Services.GameMasters
{
    public class GameMasterService : IGameMasterService
    {
        private readonly ApplicationDbContext _context;
        
        public GameMasterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<GetAllGameMastersDTO>> GetAll()
        {
            var gameMasterList = await _context.GameMasters.OrderBy(gm => gm.Id).ToListAsync();

            if (!gameMasterList.Any())
            {
                throw new Exception("There are no Game Masters saved.");
            }

            var gameMasterDTOList = new List<GetAllGameMastersDTO>();

            foreach(GameMaster gm in gameMasterList)
            {
                gameMasterDTOList.Add(new GetAllGameMastersDTO(gm.Id, gm.Name));
            }

            return gameMasterDTOList;
        }

        public async Task<GetGameMasterByIdDTO> GetById(long id)
        {
            var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);

            if (gameMaster == null)
            {
                throw new KeyNotFoundException("No Game Master matches the provided ID.");
            }

            GetGameMasterByIdDTO gmDTO = new GetGameMasterByIdDTO(gameMaster.Id, gameMaster.Name);

            return gmDTO;
        }

        public async Task Create(PostGameMasterDTO gameMaster)
        {
            GameMaster gm = new GameMaster(gameMaster.Id, gameMaster.Name);
            _context.GameMasters.Add(gm);
            await this.SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}