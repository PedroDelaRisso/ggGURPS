using System.Collections.Generic;

public class GetPlayerByIdDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<GetCampaignsDTO> Campaigns { get; set; }
    public ICollection<GetCharactersDTO> Characters { get; set; }

    public GetPlayerByIdDTO(long id, string name)
    {
        Id = id;
        Name = name;
        Campaigns = new List<GetCampaignsDTO>();
        Characters = new List<GetCharactersDTO>();
    }
}