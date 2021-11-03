public class PutCampaignDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GameMasterId { get; set; }

    public PutCampaignDTO(long id, string name, long gameMasterId)
    {
        Id = id;
        Name = name;
        GameMasterId = gameMasterId;
    }
}