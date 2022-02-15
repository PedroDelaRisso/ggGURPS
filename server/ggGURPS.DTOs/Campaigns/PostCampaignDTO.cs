public class PostCampaignDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GameMasterId { get; set; }

    public PostCampaignDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}