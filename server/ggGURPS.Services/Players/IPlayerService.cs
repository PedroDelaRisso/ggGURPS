using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayerService
{
    Task Create(PostPlayerDTO playerDTO);
    Task<List<GetPlayersDTO>> GetAll();
    Task<GetPlayerByIdDTO> GetById(long id);
    Task Update(long id, PutPlayerDTO playerDTO);
    Task Delete(long id);
}