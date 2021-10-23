namespace ggGURPS.DTOs.Skills
{
    public class GetSkillsByCharacterIdDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetSkillsByCharacterIdDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}