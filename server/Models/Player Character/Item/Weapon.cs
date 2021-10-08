namespace server.Models
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Modifier { get; set; }

        public Weapon(string name)
        {
            Name = name;
        }
    }
}