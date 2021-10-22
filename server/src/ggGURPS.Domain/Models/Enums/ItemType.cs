using System.ComponentModel;

namespace ggGURPS.Domain.Models.Enums
{
    public enum ItemType
    {
        [Description("Object")]
        Object = 1,
        [Description("Armor")]
        Armor,
        [Description("Gun")]
        Gun,
        [Description("Weapon")]
        Weapon
    }
}