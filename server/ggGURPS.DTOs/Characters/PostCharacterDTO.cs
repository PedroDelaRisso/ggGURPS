public class PostCharacterDTO
{
    public long Id { get; set; }
    public int TotalPoints { get; set; }
    public string Name { get; set; }
    public bool Npc { get; set; }
    public long CampaignId { get; set; }
    public long? GameMasterId { get; set; }
    public long? PlayerId { get; set; }

    public PostCharacterDTO(long id, int totalPoints, string name, bool npc, long? gameMasterId, long? playerId)
    {
        Id = id;
        TotalPoints = totalPoints;
        Name = name;
        Npc = npc;
        GameMasterId = gameMasterId;
        PlayerId = playerId;
    }
}