public class Inventory
{
    public long Id { get; set; }
    public long CharacterId { get; set; }
    public long ItemId { get; set; }
    public int Amount { get; set; }
    public Inventory(long id, long characterId, long itemId, int amount)
    {
        Id = id;
        CharacterId = characterId;
        ItemId = itemId;
        Amount = amount;
    }
}