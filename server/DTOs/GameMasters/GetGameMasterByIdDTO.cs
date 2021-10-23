using System.Collections.Generic;
using ggGURPS.DTOs.Campaigns;

namespace ggGURPS.DTOs.GameMasters
{
    public class GetGameMasterByIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetCampaignsByGameMasterIdDTO> Campaigns { get; set; }
        public GetGameMasterByIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}