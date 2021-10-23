using System.Collections.Generic;
using ggGURPS.DTOs.Characters;
using ggGURPS.DTOs.GameMasters;
using ggGURPS.DTOs.Players;

namespace ggGURPS.DTOs.Campaigns
{
    public class GetCampaignByIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GameMasterId { get; set; }
        public GetGameMasterByIdDTO GameMaster { get; set; }
        public ICollection<GetCharactersByCampaignIdDTO> Characters { get; set; }
        public ICollection<GetPlayersByCampaignIdDTO> Players { get; set; }

        public GetCampaignByIdDTO(long id, string name, long gameMasterId)
        {
            Id = id;
            Name = name;
            GameMasterId = gameMasterId;
        }
    }
}