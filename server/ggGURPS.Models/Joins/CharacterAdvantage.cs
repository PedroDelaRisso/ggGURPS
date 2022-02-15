public class CharacterAdvantage
{
    public long CharacterId { get; set; }
    public long AdvantageId { get; set; }
    public Character Character { get; set; }
    public Advantage Advantage { get; set; }
}