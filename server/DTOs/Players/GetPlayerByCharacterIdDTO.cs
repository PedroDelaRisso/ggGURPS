
namespace ggGURPS.DTOs.Players
{
    public class GetPlayerByCharacterIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetPlayerByCharacterIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}