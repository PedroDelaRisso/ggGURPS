using System.Collections.Generic;
using ggGURPS.Domain.Models.Enums;
using ggGURPS.Domain.Models.Characters;
using ggGURPS.Domain.Models.Rolls;

namespace ggGURPS.Domain.Models.Items
{
    public class Item
    {
        // Object
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public double Price{ get; set; }
        public double Weight{ get; set; }

        // Armor
        public int DamageReduction { get; set; }

        // Weapon
        public int SwingDamageDice { get; set; }
        public int SwingDamageModifier { get; set; }
        public int ThrustDamageDice { get; set; }
        public int ThrustDamageModifier { get; set; }

        // Gun
        public int Recoil { get; set; }
        public int Range { get; set; }
        public int RateOfFire { get; set; }
        public int DamageDice { get; set; }
        public int DamageModifier { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Roll> Rolls { get; set; }
    }
}