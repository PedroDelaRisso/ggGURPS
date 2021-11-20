using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AdvantageService : IAdvantageService
{
    private readonly ApplicationDbContext _context;

    public AdvantageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Advantage> GetAdvantageById(long id)
    {
        var advantage = await _context.Advantages.FirstOrDefaultAsync(a => a.Id == id);
        if (advantage == null)
            throw new KeyNotFoundException("Advantage not found!");
        return advantage;
    }

    private async Task<List<Advantage>> GetAllAdvantages()
    {
        var advantages = await _context.Advantages.ToListAsync();
        if (!advantages.Any())
            throw new KeyNotFoundException("There are no saved Advantages!");
        return advantages;
    }

    private async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task Create(PostAdvantageDTO advantageDTO)
    {
        var advantage = new Advantage()
        {
            Id = 0,
            Name = advantageDTO.Name,
            Description = advantageDTO.Description,
            Price = advantageDTO.Price
        };
        _context.Advantages.Add(advantage);
        await SaveAsync();
    }

    public async Task<List<AdvantagesDTO>> GetAll()
    {
        var advantageList = await GetAllAdvantages();
        var advantageDTOList = new List<AdvantagesDTO>();
        foreach(var adv in advantageList)
        {
            advantageDTOList.Add(new AdvantagesDTO(){ Id = adv.Id,
                                                      Name = adv.Name,
                                                      Price = adv.Price });
        }
        return advantageDTOList;
    }

    public async Task<GetAdvantageByIdDTO> GetById(long id)
    {
        var advantage = await GetAdvantageById(id);
        var advantageDTO = new GetAdvantageByIdDTO()
        {
            Id = advantage.Id,
            Name = advantage.Name,
            Description = advantage.Description,
            Price = advantage.Price
        };
        return advantageDTO;
    }

    public async Task<PutAdvantageDTO> Update(PutAdvantageDTO advantageDTO)
    {
        var advantage = await GetAdvantageById(advantageDTO.Id);

        advantage.Name = advantageDTO.Name;
        advantage.Description = advantageDTO.Description;
        advantage.Price = advantageDTO.Price;

        _context.Advantages.Update(advantage);
        await SaveAsync();
        return advantageDTO;
    }

    public async Task Delete(long id)
    {
        var advantage = await GetAdvantageById(id);
        _context.Advantages.Remove(advantage);
        await SaveAsync();
    }
}