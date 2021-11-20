using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CharacterService : ICharacterService
{
    private readonly ApplicationDbContext _context;

    public CharacterService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(PostCharacterDTO characterDTO)
    {
        var character = new Character(characterDTO.Id, characterDTO.TotalPoints, characterDTO.Name);

        character.TotalPoints = characterDTO.TotalPoints;
        character.RemainingPoints = characterDTO.TotalPoints;
        character.Npc = characterDTO.Npc;

        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == characterDTO.CampaignId);
        if(campaign == null)
            throw new KeyNotFoundException("Campaign not found!");
        character.CampaignId = characterDTO.CampaignId;


        if(characterDTO.Npc)
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
        await Save();
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
        if(character == null)
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
        return characterDTO;
    }

    public async Task Update(long id, PutCharacterDTO characterDTO)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if(character == null)
            throw new KeyNotFoundException("Character not found!");
        characterDTO.Id = id;
        character.Name = characterDTO.Name;
        character.Age = characterDTO.Age;
        character.Birthday = characterDTO.Birthday;
        character.PhysicalDescription = characterDTO.PhysicalDescription;
        _context.Update(character);
        await Save();
    }

    public async Task LevelUp(long id, Attributes attribute, int levels)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if(character == null)
            throw new KeyNotFoundException("Character not found!");
        switch(attribute)
        {
            case Attributes.Strength:
                character.Strength += levels;
                character.HitPoints += levels;
                break;
            case Attributes.Dexterity:
                character.Dexterity += levels;
                break;
            case Attributes.Inteligence:
                character.Inteligence += levels;
                character.Perception += levels;
                character.Will += levels;
                break;
            case Attributes.Perception:
                character.Perception += levels;
                break;
            case Attributes.Will:
                character.Will += levels;
                break;
            case Attributes.Health:
                character.Health += levels;
                character.FatiguePoints += levels;
                break;
            case Attributes.HitPoints:
                character.HitPoints += levels;
                break;
            case Attributes.FatiguePoints:
                character.FatiguePoints += levels;
                break;
        }

        character.RemainingPoints -= CalculatePointsSpent(levels, attribute);
        character.SpentPoints += CalculatePointsSpent(levels, attribute);


        _context.Update(character);
        await Save();
    }

    public async Task AddPoints(long id, int points)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if(character == null)
            throw new KeyNotFoundException("Character not found!");
        character.TotalPoints += points;
        character.RemainingPoints += points;
        _context.Update(character);
        await Save();
    }

    public async Task Delete(long id)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if(character == null)
            throw new KeyNotFoundException("Character not found!");
        _context.Characters.Remove(character);
        await Save();
    }

    private int CalculatePointsSpent(int levelsAdded, Attributes attribute)
    {
        int pointsSpent = 0;
        switch(attribute)
        {
            case Attributes.Dexterity:
            case Attributes.Inteligence:
                pointsSpent = levelsAdded * 20;
                break;
            case Attributes.Strength:
            case Attributes.Health:
                pointsSpent = levelsAdded * 10;
                break;
            case Attributes.Will:
            case Attributes.Perception:
                pointsSpent = levelsAdded * 5;
                break;
            case Attributes.FatiguePoints:
                pointsSpent = levelsAdded * 3;
                break;
            case Attributes.HitPoints:
                pointsSpent = levelsAdded * 2;
                break;
        }
        return pointsSpent;
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}