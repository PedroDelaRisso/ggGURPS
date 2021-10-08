namespace server.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public bool? Equipped { get; set; }
    }
}