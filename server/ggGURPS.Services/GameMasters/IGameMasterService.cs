using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ggGURPS.Models.GameMasters;
using ggGURPS.DTOs.GameMasters;

namespace ggGURPS.Services.GameMasters
{
    public interface IGameMasterService
    {
        Task<GameMaster> GetById(long id);
        Task Create(PostGameMasterDTO gameMaster);
        Task Save();
    }
}