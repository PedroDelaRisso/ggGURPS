using System.Collections.Generic;
using ggGURPS.Domain.Models.Enums;
using ggGURPS.Domain.Models.Characters;
using ggGURPS.Domain.Models.Rolls;

namespace ggGURPS.Domain.Models.Skills
{
    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SpentPoints { get; set; }
        public Difficulty Difficulty { get; set; }
        public BaseAttribute BaseAttribute { get; set; }
        public int Level { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Roll> Rolls { get; set; }
    }
}