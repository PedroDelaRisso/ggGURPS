using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICharacterService
{
    Task Create(PostCharacterDTO playerDTO);
    Task<List<GetCharactersDTO>> GetAll();
    Task<GetCharacterByIdDTO> GetById(long id);
    Task Update(long id, PutCharacterDTO characterDTO);
    Task LevelUp(long id, Attributes attribute, int levels);
    Task AddPoints(long id, int points);
    Task AddAdvantage(long characterId, long advantageId);
    Task Delete(long id);
}