using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ggGURPS.Models.GameMasters
{
    public interface IGameMasterService
    {
        Task<GameMaster> GetById(long id);
    }
}