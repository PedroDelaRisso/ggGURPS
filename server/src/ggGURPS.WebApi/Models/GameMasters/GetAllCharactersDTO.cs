using ggGURPS.WebApi.Models.Campaigns;

namespace ggGURPS.WebApi.Models.GameMasters
{
    public class GetCharactersDTO
    {
        public string Name { get; set; }
        public int CampaignId { get; set; }
        public GetCampaignByIdDTO Campaign { get; set; }
    }
}