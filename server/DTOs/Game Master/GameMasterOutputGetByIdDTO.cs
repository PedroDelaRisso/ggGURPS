using System.Collections.Generic;

public class GameMasterOutputGetByIdDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<CharacterOutputGetByGameMasterIdDTO> Characters { get; set; }
    public GameMasterOutputGetByIdDTO(long id, string name, ICollection<CharacterOutputGetByGameMasterIdDTO> characters)
    {
        Id = id;
        Name = name;
        Characters = characters;
    }
}