using System.Collections.Generic;

public class GetCampaignByIdDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GameMasterId { get; set; }
    public GetGameMasterByCampaignDTO GameMaster { get; set; }
    public ICollection<GetCharactersDTO> Characters { get; set; }
    public GetCampaignByIdDTO(long id, string name)
    {
        Id = id;
        Name = name;
        Characters = new List<GetCharactersDTO>();
    }
}