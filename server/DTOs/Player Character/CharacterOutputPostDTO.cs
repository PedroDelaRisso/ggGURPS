public class CharacterOutputPostDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public CharacterOutputPostDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}