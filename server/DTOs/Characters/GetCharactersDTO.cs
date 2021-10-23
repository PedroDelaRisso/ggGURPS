using ggGURPS.DTOs.Campaigns;

namespace ggGURPS.DTOs.Characters
{
    public class GetCharactersDTO
    {
        public string Name { get; set; }
        public long CampaignId { get; set; }
        public GetCampaignByIdDTO Campaign { get; set; }

        public GetCharactersDTO(string name, long campaignId)
        {
            Name = name;
            CampaignId = campaignId;
        }
    }
}