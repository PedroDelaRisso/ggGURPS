public class CharacterOutputDeleteDTO
{
    public long Id { get; set; }
    public string CharacterName { get; set; }
    
    public CharacterOutputDeleteDTO(long id, string characterName)
    {
        Id = id;
        CharacterName = characterName;
    }
}