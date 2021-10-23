
namespace ggGURPS.DTOs.Characters
{
    public class GetCharactersByCampaignIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetCharactersByCampaignIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}