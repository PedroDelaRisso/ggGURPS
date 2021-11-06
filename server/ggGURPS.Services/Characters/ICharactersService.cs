using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICharactersService
{
    Task Create(PostCharacterDTO playerDTO);
    Task<List<GetCharactersDTO>> GetAll();
}