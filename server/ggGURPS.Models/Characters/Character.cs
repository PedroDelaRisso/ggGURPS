using System.Collections.Generic;

public class Character
{
    public int Id { get; set; }
    public int AttributesId { get; set; }
    public Attributes Attributes { get; set; }
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Spell> Spells { get; set; }
    public ICollection<CustomRoll> CustomRolls { get; set; }
    public string Name { get; set; }

    public Character()
    {
        Attributes = new Attributes();
        Inventory = new Inventory();
        Skills = new List<Skill>();
        Spells = new List<Spell>();
        CustomRolls = new List<CustomRoll>();
    }

    public Character(string name)
    {
        Name = name;
        Attributes = new Attributes();
        Inventory = new Inventory();
        Skills = new List<Skill>();
        Spells = new List<Spell>();
        CustomRolls = new List<CustomRoll>();
    }
}