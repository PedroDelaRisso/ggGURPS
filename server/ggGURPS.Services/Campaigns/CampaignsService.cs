using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CampaignsService : ICampaignsService
{
    private readonly ApplicationDbContext _context;

    public CampaignsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(PostCampaignDTO campaignDTO)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(g => g.Id == campaignDTO.GameMasterId);
        if(gameMaster == null)
            throw new KeyNotFoundException("Invalid Game Master.");

        var campaign = new Campaign(campaignDTO.Id, campaignDTO.Name);
        campaign.GameMasterId = campaignDTO.GameMasterId;

        _context.Campaigns.Add(campaign);

        await Save();
    }

    public async Task<List<GetCampaignsDTO>> GetAll()
    {
        var campaignList = await _context.Campaigns.ToListAsync();
        if (!campaignList.Any())
            throw new Exception("There are no saved Campaigns!");
        var campaingListDTO = new List<GetCampaignsDTO>();
        foreach(Campaign c in campaignList)
        {
            var gameMasterName = _context.GameMasters.FirstOrDefaultAsync(g => g.Id == c.GameMasterId).Result.Name;
            campaingListDTO.Add(new GetCampaignsDTO(c.Id, c.Name, c.GameMasterId, gameMasterName));
        }

        return campaingListDTO;
    }

    public async Task Update(long id, PutCampaignDTO campaignDTO)
    {
        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == id);
        if(campaign == null)
            throw new KeyNotFoundException();
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(g => g.Id == campaignDTO.GameMasterId);
        if(gameMaster == null)
            throw new KeyNotFoundException();

        campaignDTO.Id = id;
        campaign.Id = campaignDTO.Id;
        campaign.Name = campaignDTO.Name;
        campaign.GameMasterId = campaignDTO.GameMasterId;

        _context.Update(campaign);
        await Save();
    }

    public async Task<GetCampaignByIdDTO> GetById(long id)
    {
        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == id);
        if(campaign == null)
            throw new KeyNotFoundException();
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(g => g.Id == campaign.GameMasterId);

        var campaignDTO = new GetCampaignByIdDTO(campaign.Id, campaign.Name);
        campaignDTO.GameMaster = new GetGameMasterByCampaignDTO(gameMaster.Id, gameMaster.Name);

        var characters = await _context.Characters.ToListAsync();
        var charactersDTO = new List<GetCharactersDTO>();

        foreach(Character c in characters)
        {
            if(c.CampaignId == id)
                charactersDTO.Add(new GetCharactersDTO(c.Id, c.Name));
        }

        campaignDTO.Characters = charactersDTO;

        return campaignDTO;
    }

    public async Task Delete(long id)
    {
        var campaign = await _context.Campaigns.FirstOrDefaultAsync(c => c.Id == id);
        if(campaign == null)
            throw new KeyNotFoundException();
        _context.Campaigns.Remove(campaign);
        await Save();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}