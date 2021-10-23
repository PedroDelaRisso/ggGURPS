using System.ComponentModel;

namespace ggGURPS.Domain.Models.Enums
{
    public enum BaseAttribute
    {
        [Description("Strength")]
        Strength,
        [Description("Dexterity")]
        Dexterity,
        [Description("Inteligence")]
        Inteligence,
        [Description("Health")]
        Health,
        [Description("Will")]
        Will,
        [Description("Perception")]
        Perception,
        [Description("Defenses")]
        Defenses,
        [Description("Parry")]
        Parry,
        [Description("Block")]
        Block,
        [Description("Dodge")]
        Dodge
    }
}