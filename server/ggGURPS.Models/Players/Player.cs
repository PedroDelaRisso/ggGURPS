using System.Collections.Generic;

public class Player
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Character> Characters { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }

    public Player(long id, string name)
    {
        Id = id;
        Name = name;
        Characters = new List<Character>();
        Campaigns = new List<Campaign>();
    }
}