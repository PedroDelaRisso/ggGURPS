using System.Collections.Generic;
using ggGURPS.WebApi.Models.Characters;
using ggGURPS.WebApi.Models.GameMasters;
using ggGURPS.WebApi.Models.Players;

namespace ggGURPS.WebApi.Models.Campaigns
{
    public class GetCampaignByIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GameMasterId { get; set; }
        public GetGameMasterByCharacterIdDTO GameMaster { get; set; }
        public ICollection<GetCharactersByCampaignIdDTO> Characters { get; set; }
        public ICollection<GetPlayersByCampaignIdDTO> Players { get; set; }
    }
}