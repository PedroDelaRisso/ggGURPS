public class GetGameMasterByCampaignDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public GetGameMasterByCampaignDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}