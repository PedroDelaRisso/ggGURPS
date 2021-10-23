namespace ggGURPS.DTOs.Campaigns
{
    public class GetCampaignsByGameMasterIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public GetCampaignsByGameMasterIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}