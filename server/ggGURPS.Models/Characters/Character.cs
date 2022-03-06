using System.Collections.Generic;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Attributes
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Inteligence { get; set; }
    public int Health { get; set; }
    public int Perception { get; set; }
    public int Will { get; set; }
    public int Magery { get; set; }
    public int DamageReduction { get; set; }
    public int HitPoints { get; set; }
    public int FatiguePoints { get; set; }
    public int EnergyReserves { get; set; }


    public ICollection<Item> Items { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Spell> Spells { get; set; }
    public ICollection<CustomRoll> CustomRolls { get; set; }

    public Character()
    {
        Items = new List<Item>();
        Skills = new List<Skill>();
        Spells = new List<Spell>();
        CustomRolls = new List<CustomRoll>();
    }

    public Character(string name)
    {
        Name = name;
        Items = new List<Item>();
        Skills = new List<Skill>();
        Spells = new List<Spell>();
        CustomRolls = new List<CustomRoll>();
    }
}