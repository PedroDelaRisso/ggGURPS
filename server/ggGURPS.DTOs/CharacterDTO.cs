using System.Collections.Generic;

public class CharacterDTO
{
    public string Name { get; set; }
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
    public List<PostItemDTO> Items { get; set; }
    public List<PostSkillDTO> Skill { get; set; }
}