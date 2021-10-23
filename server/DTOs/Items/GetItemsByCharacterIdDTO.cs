namespace ggGURPS.DTOs.Items
{
    public class GetItemsByCharacterIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetItemsByCharacterIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}