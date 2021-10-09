public class PlayerCharacterOutputAllDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    public long GameMasterId { get; set; }
    
    public PlayerCharacterOutputAllDTO(long id, string characterName, long gameMasterId)
    {
        Id = id;
        CharacterName = characterName;
        GameMasterId = gameMasterId;
    }
}