using System.ComponentModel;

namespace ggGURPS.Domain.Models.Enums
{
    public enum Difficulty
    {
        [Description("Easy")]
        Easy,
        [Description("Average")]
        Average,
        [Description("Hard")]
        Hard,
        [Description("Very Hard")]
        VeryHard
    }
}