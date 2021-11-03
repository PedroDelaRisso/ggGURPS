public class GetCampaignsDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GameMasterId { get; set; }
    public string GameMasterName { get; set; }

    public GetCampaignsDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
    public GetCampaignsDTO(long id, string name, long gameMasterId, string gameMasterName)
    {
        Id = id;
        Name = name;
        GameMasterId = gameMasterId;
        GameMasterName = gameMasterName;
    }
}