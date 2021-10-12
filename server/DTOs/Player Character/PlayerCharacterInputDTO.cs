public class PlayerCharacterInputDTO
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

    public PlayerCharacterInputDTO(long id,
                                    string characterName,
                                    int strength,
                                    int dexterity,
                                    int inteligence,
                                    int health,
                                    int fatiguePoints,
                                    int hitPoints,
                                    long gameMasterId)
    {
        Id = id;
        CharacterName = characterName;
        Strength = strength;
        Dexterity = dexterity;
        Inteligence = inteligence;
        Health = health;
        FatiguePoints = fatiguePoints;
        HitPoints = hitPoints;
        GameMasterId = gameMasterId;
    }
}