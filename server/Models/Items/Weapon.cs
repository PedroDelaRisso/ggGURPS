namespace server.Models
{
    public class Weapon : IItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Damage { get; set; }
        public int Modifier { get; set; }
        public bool? Equipped { get; set; }

        public Weapon(string name)
        {
            Name = name;
        }
    }
}