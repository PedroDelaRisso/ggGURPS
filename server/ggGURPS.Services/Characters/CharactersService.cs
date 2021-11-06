using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CharactersService : ICharactersService
{
    private readonly ApplicationDbContext _context;

    public CharactersService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(PostCharacterDTO characterDTO)
    {
        var character = new Character(characterDTO.Id, characterDTO.TotalPoints, characterDTO.Name);

        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == characterDTO.CampaignId);
        if(campaign == null)
            throw new KeyNotFoundException("Campaign not found!");
        character.CampaignId = characterDTO.CampaignId;

        if (characterDTO.Npc)
        {
            character.PlayerId = null;
            character.GameMasterId = characterDTO.GameMasterId;
        }
        else
        {
            character.PlayerId = characterDTO.PlayerId;
            character.GameMasterId = null;
        }

        _context.Characters.Add(character);
        await this.Save();
    }

    public async Task<List<GetCharactersDTO>> GetAll()
    {
        var characters = await _context.Characters.ToListAsync();
        if(!characters.Any())
            throw new Exception("There are no saved Characters!");

        var charactersDTO = new List<GetCharactersDTO>();
        foreach(Character c in characters)
        {
            charactersDTO.Add(new GetCharactersDTO(c.Id, c.Name));
        }
        return charactersDTO;
    }

    public async Task<GetCharacterByIdDTO> GetById(long id)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            throw new KeyNotFoundException("Character not found!");
        string playerName = "";
        string gameMasterName = "";
        if(character.Npc)
            gameMasterName = _context.GameMasters.FirstOrDefaultAsync(g => g.Id == character.GameMasterId).Result.Name;
        else
            playerName = _context.Players.FirstOrDefaultAsync(p => p.Id == character.PlayerId).Result.Name;
        string campaignName = _context.Campaigns.FirstOrDefaultAsync(c => c.Id == character.CampaignId).Result.Name;
        var characterDTO = new GetCharacterByIdDTO(character.Id,
                                                    character.Name,
                                                    character.Age,
                                                    character.Birthday,
                                                    character.PhysicalDescription,
                                                    character.TotalPoints,
                                                    character.SpentPoints,
                                                    character.RemainingPoints,
                                                    character.Strength,
                                                    character.Dexterity,
                                                    character.Inteligence,
                                                    character.Health,
                                                    character.HitPoints,
                                                    character.FatiguePoints,
                                                    character.Will,
                                                    character.Perception,
                                                    character.Npc,
                                                    character.PlayerId,
                                                    playerName,
                                                    character.GameMasterId,
                                                    gameMasterName,
                                                    character.CampaignId,
                                                    campaignName);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}