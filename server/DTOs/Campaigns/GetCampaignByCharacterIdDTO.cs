using System.Collections.Generic;
using ggGURPS.DTOs.Characters;
using ggGURPS.DTOs.GameMasters;
using ggGURPS.DTOs.Players;

namespace ggGURPS.DTOs.Campaigns
{
    public class GetCampaignByCharacterIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GameMasterId { get; set; }

        public GetCampaignByCharacterIdDTO(long id, string name, long gameMasterId)
        {
            Id = id;
            Name = name;
            GameMasterId = gameMasterId;
        }
    }
}