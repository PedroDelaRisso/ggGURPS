using System.Collections.Generic;
using ggGURPS.Domain.Models.Characters;
using ggGURPS.Domain.Models.Campaigns;

namespace ggGURPS.Domain.Models.Players
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}