using System.Collections.Generic;

public class PlayerCharacter
{
    public long Id { get; set; }

    public string CharacterName { get; set; }

    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Inteligence { get; set; }
    public int Health { get; set; }

    public int FatiguePoints { get; set; }
    public int HitPoints { get; set; }

    public long GameMasterId { get; set; }

    public PlayerCharacter(string characterName)
    {
        CharacterName = characterName;
    }
}