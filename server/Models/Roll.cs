public class Roll
{
    public long Id { get; set; }
    public long? GameMasterId { get; set;}
    public long? CharacterId { get; set; }
    public long? RollTypeId { get; set; }
    public long RollIndex { get; set; }
    public RollType RollType { get; set; }
    public int NumberOfDice { get; set; }
    public int Modififer { get; set; }
    public int Result { get; set; }
}