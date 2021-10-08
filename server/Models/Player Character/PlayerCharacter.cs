using System.Collections.Generic;


namespace server.Models
{
    public class PlayerCharacter
    {
        public long Id { get; set; }

        public string CharacterName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PlayerName { get; set; }

        public int Points { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Health { get; set; }

        public int FatiguePoints { get; set; }
        public int HitPoints { get; set; }

        public int Will { get; set; }
        public int Perception { get; set; }

        public ICollection<AdvantageAndDisadvantage> AdvantagesAndDisadvantages { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public ICollection<IItem> Inventory { get; set; }

        public long GameMasterId { get; set; }
        public GameMaster GameMaster { get; set; }

        public PlayerCharacter(string characterName, string age, string gender)
        {
            CharacterName = characterName;
            Age = age;
            Gender = gender;
        }
    }
}