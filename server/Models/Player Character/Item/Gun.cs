namespace server.Models
{
    public class Gun : Item
    {
        public int Damage { get; set; }
        public int Modifier { get; set; }
        public int Recoil { get; set; }
        public int FireRate { get; set; }
        public double Range { get; set; }

        public Gun(string name)
        {
            Name = name;
        }
    }
}