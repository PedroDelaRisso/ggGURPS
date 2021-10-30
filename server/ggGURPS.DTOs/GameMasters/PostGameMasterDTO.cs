using System.Collections.Generic;
using ggGURPS.Models.Campaigns;
using ggGURPS.Models.Rolls;

namespace ggGURPS.DTOs.GameMasters
{
    public class PostGameMasterDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public PostGameMasterDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}