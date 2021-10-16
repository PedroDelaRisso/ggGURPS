public class Roll
{
    public long Id { get; set; }
    public long CharacterId { get; set; }
    public long? RollTypeId { get; set; }
    public long RollIndex { get; set; }
    public RollType RollType { get; set; }
    public int NumberOfDice { get; set; }
    public int Modififer { get; set; }
    public int Result { get; set; }
}

/***
    Roll history mechanic: Saves the last 10 rolls of any Character.
        Each time a roll of CharacterId = X happens, RollIndex (starting at 10) is subtracted by 1.
    The most recent roll of CharacterId X always has RollIndex of 10. Whenever the RollIndex of
    any roll hits zero, the same roll is deleted from the database
*/