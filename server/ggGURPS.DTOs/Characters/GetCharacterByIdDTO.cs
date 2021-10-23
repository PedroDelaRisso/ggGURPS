using System.Collections.Generic;
using ggGURPS.DTOs.Advantages;
using ggGURPS.DTOs.Skills;
using ggGURPS.DTOs.Items;
using ggGURPS.DTOs.Rolls;
using ggGURPS.DTOs.Players;
using ggGURPS.DTOs.Campaigns;

namespace ggGURPS.DTOs.Characters
{
    public class GetCharacterByIdDTO
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
        public long PlayerId { get; set; }
        public GetPlayerByCharacterIdDTO Player { get; set; }
        public long CampaignId { get; set; }
        public GetCampaignByCharacterIdDTO Campaign { get; set; }
        public ICollection<GetAdvatangesByCharacterIdDTO> Advantages { get; set; }
        public ICollection<GetSkillsByCharacterIdDTO> Skills { get; set; }
        public ICollection<GetItemsByCharacterIdDTO> Items { get; set; }
        public ICollection<GetRollsByCharacterIdDTO> Rolls { get; set; }

        public GetCharacterByIdDTO(
            long id,
            string name,
            string age,
            string birthday,
            string physicalDescription,
            int totalPoints,
            int spentPoints,
            int remainingPoints,
            int strength,
            int dexterity,
            int inteligence,
            int health,
            int hitPoints,
            int fatiguePoints,
            int will,
            int perception,
            bool npc,
            long playerId,
            long campaignId
        )
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthday;
            PhysicalDescription = physicalDescription;
            TotalPoints = totalPoints;
            SpentPoints = spentPoints;
            RemainingPoints = remainingPoints;
            Strength = strength;
            Dexterity = dexterity;
            Inteligence = inteligence;
            Health = health;
            HitPoints = hitPoints;
            FatiguePoints = fatiguePoints;
            Will = will;
            Perception = perception;
            Npc = npc;
            PlayerId = playerId;
            CampaignId = campaignId;
        }
    }
}