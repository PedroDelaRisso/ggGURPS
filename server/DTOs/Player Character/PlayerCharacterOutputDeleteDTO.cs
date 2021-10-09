public class PlayerCharacterOutputDeleteDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public PlayerCharacterOutputDeleteDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}