using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class GameMastersService : IGameMasterService
{
    private readonly ApplicationDbContext _context;
    public GameMastersService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(PostGameMasterDTO gameMasterDTO)
    {
        var gameMaster = new GameMaster(gameMasterDTO.Id, gameMasterDTO.Name);
        _context.GameMasters.Add(gameMaster);

        await Save();
    }

    public async Task<List<GetGameMastersDTO>> GetAll()
    {
        var gameMasterList = await _context.GameMasters.ToListAsync();

        if(!gameMasterList.Any())
            throw new Exception("There are no saved Game Masters!");

        var gameMasterDTOList = new List<GetGameMastersDTO>();
        foreach(GameMaster gm in gameMasterList)
        {
            gameMasterDTOList.Add(new GetGameMastersDTO(gm.Id, gm.Name));
        }
        return gameMasterDTOList;
    }

    public async Task<GetGameMasterByIdDTO> GetById(long id)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(g => g.Id == id);
        if(gameMaster == null)
            throw new KeyNotFoundException();

        var campaigns = await _context.Campaigns.Where(c => c.GameMasterId == gameMaster.Id).ToListAsync();

        var gameMasterDTO = new GetGameMasterByIdDTO(gameMaster.Id, gameMaster.Name);
        foreach(Campaign campaign in campaigns)
        {
            gameMasterDTO.Campaigns.Add(new GetCampaignsByGameMasterDTO(campaign.Id, campaign.Name));
        }

        var characters = await _context.Characters.Where(c => c.GameMasterId == id).ToListAsync();
        foreach(Character character in characters)
        {
            gameMasterDTO.Characters.Add(new GetCharactersDTO(character.Id, character.Name));
        }

        return gameMasterDTO;

    }

    public async Task Update(PutGameMasterDTO gameMasterDTO)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync();
        if(gameMaster == null)
            throw new KeyNotFoundException();
        gameMaster.Id = gameMasterDTO.Id;
        gameMaster.Name = gameMasterDTO.Name;

        _context.GameMasters.Update(gameMaster);
        await Save();
    }

    public async Task Delete(long id)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(g => g.Id == id);
        if(gameMaster == null)
            throw new KeyNotFoundException();

        _context.GameMasters.Remove(gameMaster);
        await Save();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}