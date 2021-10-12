public class PlayerCharacterOutputGetByGameMasterIdDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public PlayerCharacterOutputGetByGameMasterIdDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}