using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    public int Id { get; set; }
    [ForeignKey("InventoryId")]
    public int InventoryId { get; set; }
    public int ItemStatsId { get; set; }
    public ItemStats ItemStats { get; set; }
    public ItemTypes Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Item()
    {
        ItemStats = new ItemStats();
    }
}