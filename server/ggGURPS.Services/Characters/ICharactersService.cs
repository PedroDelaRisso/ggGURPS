using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICharactersService
{
    Task Create(PostCharacterDTO playerDTO);
    Task<List<GetCharactersDTO>> GetAll();
    Task<GetCharacterByIdDTO> GetById(long id);
    Task Update(long id, PutCharacterDTO characterDTO);
    Task Delete(long id);
}