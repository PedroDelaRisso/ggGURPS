using System.Collections.Generic;
using ggGURPS.Domain.Models.Enums;
using ggGURPS.Domain.Models.Rolls;
using ggGURPS.Domain.Models.Characters;

namespace ggGURPS.Domain.Models.Advantages
{
    public class Advantage
    {
        public long Id { get; set; }
        public int Price { get; set; }
        public AffectedAttribute AffectedAttribute { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Roll> Rolls { get; set; }
    }
}