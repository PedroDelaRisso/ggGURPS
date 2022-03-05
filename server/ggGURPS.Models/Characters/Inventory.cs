using System.Collections.Generic;

public class Inventory
{
    public int Id { get; set; }
    public ICollection<Item> Items { get; set; }

    public Inventory()
    {
        Items = new List<Item>();
    }
}