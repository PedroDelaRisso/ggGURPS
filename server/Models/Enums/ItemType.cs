using System.ComponentModel;

public enum ItemType
{
    [Description("Item")]
    Item = 1,
    [Description("Armor")]
    Armor,
    [Description("Gun")]
    Gun,
    [Description("Weapon")]
    Weapon
}