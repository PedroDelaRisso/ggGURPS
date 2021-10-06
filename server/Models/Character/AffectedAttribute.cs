using System.ComponentModel;

public enum AffectedAttribute
{
    [Description("Not Applicable")]
    NotApplicable = -1,
    [Description("Strength")]
    Strength = 1,
    [Description("Dexterity")]
    Dexterity,
    [Description("Inteligence")]
    Inteligence,
    [Description("Health")]
    Health,
    [Description("Hit Points")]
    HitPoints,
    [Description("Fatigue Points")]
    FatiguePoints,
    [Description("Will")]
    Will,
    [Description("Perception")]
    Perception,
}
