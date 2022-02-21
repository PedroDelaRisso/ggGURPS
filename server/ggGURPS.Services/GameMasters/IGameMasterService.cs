using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGameMasterService
{
    Task<List<GetGameMastersDTO>> GetAll();
    Task<GetGameMasterByIdDTO> GetById(long id);
    Task<GameMaster> Create(PostGameMasterDTO gameMasterDTO);

    Task Update(PutGameMasterDTO gameMasterDTO);
    Task Delete(long id);
}