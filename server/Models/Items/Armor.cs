namespace server.Models
{
    public class Armor : IItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int DamageReduction { get; set; }
        public bool? Equipped { get; set; }

        public Armor(string name)
        {
            Name = name;
        }
    }
}