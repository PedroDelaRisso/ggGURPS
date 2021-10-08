namespace server.Models
{
    public class Armor : Item
    {
        public int DamageReduction { get; set; }
        public Armor(string name)
        {
            Name = name;
        }
    }
}