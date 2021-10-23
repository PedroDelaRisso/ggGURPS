using System.Collections.Generic;
using ggGURPS.Models.GameMasters;
using ggGURPS.Models.Characters;
using ggGURPS.Models.Players;

namespace ggGURPS.Models.Campaigns
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