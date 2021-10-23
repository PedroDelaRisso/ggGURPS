using ggGURPS.Models.Characters;
using ggGURPS.Models.Advantages;
using ggGURPS.Models.GameMasters;
using ggGURPS.Models.Skills;
using ggGURPS.Models.Items;

namespace ggGURPS.Models.Rolls
{
    public class Roll
    {
        public long Id { get; set; }
        public uint NumberOfDice { get; set; }
        public int Modifier { get; set; }
        public int RollResult { get; set; }
        public int FinalResult { get; set; }
        public int Index { get; set; }
        public bool Success { get; set; }

        public long? CharacterId { get; set; }
        public Character Character { get; set; }
        public long? GameMasterId { get; set; }
        public GameMaster GameMaster { get; set; }
        public long? AdvantageId { get; set; }
        public Advantage Advantage { get; set; }
        public long? SkillId { get; set; }
        public Skill Skill { get; set; }
        public long? ItemId { get; set; }
        public Item Item { get; set; }
    }
}