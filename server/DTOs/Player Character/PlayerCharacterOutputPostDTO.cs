public class PlayerCharacterOutputPostDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public PlayerCharacterOutputPostDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}