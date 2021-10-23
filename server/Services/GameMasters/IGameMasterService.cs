using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ggGURPS.Models.GameMasters;

namespace ggGURPS.Services.GameMasters
{
    public interface IGameMasterService
    {
        Task<GameMaster> GetById(long id);
    }
}