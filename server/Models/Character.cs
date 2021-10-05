using System.Collections.Generic;

public class Character {
    public long Id { get; set; }

    public string CharacterName { get; set; }
    public string Age { get; set; }
    public string Gender { get; set; }
    public string PlayerName { get; set; }

    public int Points { get; set; }

    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Inteligence { get; set; }
    public int Health { get; set; }

    public int FatiguePoints { get; set; }
    public int HitPoints { get; set; }

    public int Will { get; set; }
    public int Perception { get; set; }

    public ICollection<Advantage> Advantages { get; set; }
    public ICollection<Disadvantage> Disadvantages { get; set; }

    public Character(string characterName, string age, string gender)
    {
        CharacterName = characterName;
        Age = age;
        Gender = gender;
    }
}