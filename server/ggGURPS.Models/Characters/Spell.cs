public class Spell
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public int DamageDice { get; set; }
    public float Modifier { get; set; }
    public int CostToCast { get; set; }
    public int CostToMaintain { get; set; }

    public Spell() { }
}