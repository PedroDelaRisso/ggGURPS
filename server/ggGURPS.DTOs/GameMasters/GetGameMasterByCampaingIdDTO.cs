using ggGURPS.DTOs.Campaigns;

namespace ggGURPS.DTOs.GameMasters
{
    public class GetGameMasterByCampaingIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public GetGameMasterByCampaingIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}