namespace server.Models
{
    public class Gun : IItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int Damage { get; set; }
        public int Modifier { get; set; }
        public int Recoil { get; set; }
        public int FireRate { get; set; }
        public double Range { get; set; }
        public bool? Equipped { get; set; }

        public Gun(string name)
        {
            Name = name;
        }
    }
}