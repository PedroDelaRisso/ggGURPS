using System.Collections.Generic;

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
    public long? PlayerId { get; set; }
    public string PlayerName { get; set; }
    public long? GameMasterId { get; set; }
    public string GameMasterName { get; set; }
    public long CampaignId { get; set; }
    public string CampaignName { get; set; }
    public ICollection<AdvantagesDTO> Advantages { get; set; }
    // public ICollection<GetSkillsDTO> Skills { get; set; }
    // public ICollection<GetItemsDTO> Items { get; set; }
    // public ICollection<GetRollsDTO> Rolls { get; set; }
    public GetCharacterByIdDTO(long id,
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
                                long? playerId,
                                string playerName,
                                long? gameMasterId,
                                string gameMasterName,
                                long campaignId,
                                string campaignName)
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
        PlayerName = playerName;
        GameMasterId = gameMasterId;
        GameMasterName = gameMasterName;
        CampaignId = campaignId;
        CampaignName = campaignName;
        Advantages = new List<AdvantagesDTO>();
        //Skills = new List<GetSkillsDTO>();
        //Items = new List<GetItemsDTO>();
    }
}