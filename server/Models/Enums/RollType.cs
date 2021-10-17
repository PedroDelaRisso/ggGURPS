using System.ComponentModel;

public enum RollType
{
    [Description("Success")]
    Success = 1,
    [Description("Attribute")]
    Attribute,
    [Description("Skill")]
    Skill,
    [Description("Damage")]
    Damage,
    [Description("Shots")]
    Shots,
}