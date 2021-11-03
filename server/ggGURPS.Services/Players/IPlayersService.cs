using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayersService
{
    Task Create(PostPlayerDTO playerDTO);
    Task<List<GetPlayersDTO>> GetAll();
    Task<GetPlayerByIdDTO> GetById(long id);
    Task Update(PutPlayerDTO playerDTO);
    Task Delete(long id);
}