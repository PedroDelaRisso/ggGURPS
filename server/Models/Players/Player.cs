using System.Collections.Generic;
using ggGURPS.Models.Characters;
using ggGURPS.Models.Campaigns;

namespace ggGURPS.Models.Players
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}