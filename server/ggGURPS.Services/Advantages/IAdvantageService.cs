using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAdvantageService
{
    Task Create(PostAdvantageDTO advantageDTO);
    Task<List<AdvantagesDTO>> GetAll();
    Task<GetAdvantageByIdDTO> GetById(long id);
    Task<PutAdvantageDTO> Update(PutAdvantageDTO advantageDTO);
    Task Delete(long id);
}