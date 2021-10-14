public class Item
{
    // Item
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType ItemType { get; set; }
    public double? Price{ get; set; }
    public double? Weight{ get; set; }

    // Armor
    public uint DamageReduction { get; set; }

    // Weapon
    public uint SwingDamageDice { get; set; }
    public int SwingDamageModifier { get; set; }
    public uint ThrustDamageDice { get; set; }
    public int ThrustDamageModifier { get; set; }

    // Gun
    public uint Recoil { get; set; }
    public uint Range { get; set; }
    public uint RateOfFire { get; set; }
    public uint DamageDice { get; set; }
    public int DamageModifier { get; set; }

    // Empty Item Constructor
    public Item() { }

    // Item Item constructor
    public Item(long id, string name, string description, ItemType itemType, double? price, double? weight)
    {
        Id = id;
        Name = name;
        Description = description;
        ItemType = itemType;
        if (price != null)
        {
            Price = price;
        }
        if (weight != null)
        {
            Weight = weight;
        }
    }

    // Armor Item constructor
    public Item(long id, string name, string description, ItemType itemType, uint damageReduction, double? price, double? weight)
    {
        Id = id;
        Name = name;
        Description = description;
        ItemType = itemType;

        DamageReduction = damageReduction;

        if (price != null)
        {
            Price = price;
        }
        if (weight != null)
        {
            Weight = weight;
        }
    }

    // Weapon Item constructor
    public Item(long id, string name, string description, ItemType itemType, uint swingDamageDice, int swingDamageModifier, uint thrustDamageDice, int thrustDamageModifier, double? price, double? weight)
    {
        Id = id;
        Name = name;
        Description = description;
        ItemType = itemType;

        SwingDamageDice = swingDamageDice;
        SwingDamageModifier = swingDamageModifier;
        ThrustDamageDice = thrustDamageDice;
        ThrustDamageModifier = thrustDamageModifier;

        if (price != null)
        {
            Price = price;
        }
        if (weight != null)
        {
            Weight = weight;
        }
    }

    // Gun Item constructor
    public Item(long id, string name, string description, ItemType itemType, uint recoil, uint rateOfFire, uint damageDice, int damageModifier, double? price, double? weight)
    {
        Id = id;
        Name = name;
        Description = description;
        ItemType = itemType;

        Recoil = recoil;
        RateOfFire = rateOfFire;
        DamageDice = damageDice;
        DamageModifier = damageModifier;

        if (price != null)
        {
            Price = price;
        }
        if (weight != null)
        {
            Weight = weight;
        }
    }
}