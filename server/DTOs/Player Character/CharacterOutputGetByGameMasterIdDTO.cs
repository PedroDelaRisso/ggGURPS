public class CharacterOutputGetByGameMasterIdDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public CharacterOutputGetByGameMasterIdDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}