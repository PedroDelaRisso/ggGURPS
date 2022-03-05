public class PostItemDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int? SkillId { get; set; }
    public int DamageType { get; set; }
    public int DamageDice { get; set; }
    public float Modifier { get; set; }
    public int Recoil { get; set; }
    public int RateOfFire { get; set; }
    public int Shots { get; set; }
    public int ArmorDivisor { get; set; }
    public int Range { get; set; }
    public ItemTypes Type { get; set; }

}