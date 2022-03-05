public class CustomRoll
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    public RollTypes Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ChallengeRating { get; set; }

    public CustomRoll() { }
}