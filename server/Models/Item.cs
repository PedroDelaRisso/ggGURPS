public class Item
{
    // Item
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

    public Item(long id,
                string name,
                string description,
                ItemType itemType,
                double price,
                double weight,
                int damageReduction,
                int swingDamageDice,
                int swingDamageModifier,
                int thrustDamageDice,
                int thrustDamageModifier,
                int recoil,
                int range,
                int rateOfFire,
                int damageDice,
                int damageModifier
    )
    {
        Id = id;
        Name = name;
        Description = description;
        ItemType = itemType;
        Price = price;
        Weight = weight;
        DamageReduction = damageReduction;
        SwingDamageDice = swingDamageDice;
        SwingDamageModifier = swingDamageModifier;
        ThrustDamageDice = thrustDamageDice;
        ThrustDamageModifier = thrustDamageModifier;
        Recoil = recoil;
        Range = range;
        RateOfFire = rateOfFire;
        DamageDice = damageDice;
        DamageModifier = damageModifier;
    }
}