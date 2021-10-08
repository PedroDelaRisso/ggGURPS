using System.Collections.Generic;

namespace server.Models
{
    public class GameMaster
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<PlayerCharacter> PlayerCharacters { get; set; }

        public GameMaster(string name)
        {
            Name = name;
        }
    }
}