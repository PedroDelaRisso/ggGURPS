using System.Collections.Generic;
using ggGURPS.Models.Players;
using ggGURPS.Models.Advantages;
using ggGURPS.Models.Campaigns;
using ggGURPS.Models.Skills;
using ggGURPS.Models.Items;
using ggGURPS.Models.Rolls;

namespace ggGURPS.Models.Characters
{
    public class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Birthday { get; set; }
        public string PhysicalDescription { get; set; }
        public int TotalPoints { get; set; }
        public int SpentPoints { get; set; }
        public int RemainingPoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Health { get; set; }
        public int HitPoints { get; set; }
        public int FatiguePoints { get; set; }
        public int Will { get; set; }
        public int Perception { get; set; }
        public bool Npc { get; set; }
        public long? PlayerId { get; set; }
        public Player Player { get; set; }
        public long CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public ICollection<Advantage> Advantages { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Roll> Rolls { get; set; }
    }
}