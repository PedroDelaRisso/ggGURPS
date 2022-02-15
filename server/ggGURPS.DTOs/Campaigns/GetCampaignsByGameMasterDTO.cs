public class GetCampaignsByGameMasterDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public GetCampaignsByGameMasterDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}