using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGameMastersService
{
    Task<List<GetGameMastersDTO>> GetAll();
    Task<GetGameMasterByIdDTO> GetById(long id);
    Task Create(PostGameMasterDTO gameMasterDTO);

    Task Update(PutGameMasterDTO gameMasterDTO);
    Task Delete(long id);
}