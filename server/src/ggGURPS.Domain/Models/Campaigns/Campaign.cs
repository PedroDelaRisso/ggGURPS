using System.Collections.Generic;
using ggGURPS.Domain.Models.GameMasters;
using ggGURPS.Domain.Models.Characters;
using ggGURPS.Domain.Models.Players;

namespace ggGURPS.Domain.Models.Campaigns
{
    public class Campaign
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long GameMasterId { get; set; }
        public GameMaster GameMaster { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}