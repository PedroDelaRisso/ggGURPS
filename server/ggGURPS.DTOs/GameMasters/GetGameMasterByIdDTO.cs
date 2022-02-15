using System.Collections.Generic;

public class GetGameMasterByIdDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<GetCampaignsByGameMasterDTO> Campaigns { get; set; }
    public ICollection<GetCharactersDTO> Characters { get; set; }
    public ICollection<GetRollsDTO> Rolls { get; set; }
    public GetGameMasterByIdDTO(long id, string name)
    {
        Id = id;
        Name = name;
        Campaigns = new List<GetCampaignsByGameMasterDTO>();
        Characters = new List<GetCharactersDTO>();
        Rolls = new List<GetRollsDTO>();
    }
}