using System.ComponentModel;

public enum BaseAttribute
{
    [Description("Strength")]
    ST = 1,
    [Description("Dexterity")]
    DX,
    [Description("Inteligence")]
    IQ,
    [Description("Health")]
    HT,
    [Description("Perception")]
    Per,
    [Description("Will")]
    Will
}