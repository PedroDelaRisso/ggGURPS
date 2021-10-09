using System.Collections.Generic;

public class GameMasterOutputGetByIdDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<PlayerCharacterOutputGetByGameMasterIdDTO> PlayerCharacters { get; set; }
    public GameMasterOutputGetByIdDTO(long id, string name, ICollection<PlayerCharacterOutputGetByGameMasterIdDTO> playerCharacters)
    {
        Id = id;
        Name = name;
        playerCharacters = PlayerCharacters;
    }
}