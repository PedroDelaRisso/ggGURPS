using System.Collections.Generic;
using ggGURPS.Domain.Models.Campaigns;
using ggGURPS.Domain.Models.Rolls;

namespace ggGURPS.Domain.Models.GameMasters
{
    public class GameMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }
        public ICollection<Roll> Rolls { get; set; }
    }
}