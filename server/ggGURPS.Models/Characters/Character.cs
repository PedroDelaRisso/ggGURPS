using System.Collections.Generic;
public class Character
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public string Birthday { get; set; }
    public string PhysicalDescription { get; set; }
    public int TotalPoints { get; set; }
    public int SpentPoints { get; set; }
    public int RemainingPoints { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Inteligence { get; set; }
    public int Health { get; set; }
    public int HitPoints { get; set; }
    public int FatiguePoints { get; set; }
    public int Will { get; set; }
    public int Perception { get; set; }
    public bool Npc { get; set; }
    public long? PlayerId { get; set; }
    public Player Player { get; set; }
    public long? GameMasterId { get; set; }
    public GameMaster GameMaster { get; set; }
    public long CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public ICollection<Advantage> Advantages { get; set; }
    public ICollection<Skill> Skills { get; set; }

    public Character(long id, int totalPoints, string name)
    {
        Id = id;
        TotalPoints = totalPoints;
        Name = name;

        Age = "";
        Birthday = "";
        PhysicalDescription = "";

        Strength = 10;
        Dexterity = 10;
        Inteligence = 10;
        Health = 10;
        HitPoints = 10;
        FatiguePoints = 10;
        Will = 10;
        Perception = 10;
        Npc = false;

        Advantages = new List<Advantage>();
        Skills = new List<Skill>();

    }
}