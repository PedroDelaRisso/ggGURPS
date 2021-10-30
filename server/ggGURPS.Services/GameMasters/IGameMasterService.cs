using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ggGURPS.DTOs.GameMasters;

namespace ggGURPS.Services.GameMasters
{
    public interface IGameMasterService
    {
        Task<ICollection<GetAllGameMastersDTO>> GetAll();
        Task<GetGameMasterByIdDTO> GetById(long id);
        Task Create(PostGameMasterDTO gameMaster);
    }
}