using System.Collections.Generic;

public class Campaign
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long GameMasterId { get; set; }
    public GameMaster GameMaster { get; set; }
    public ICollection<Character> Characters { get; set; }
    public Campaign(long id, string name)
    {
        Id = id;
        Name = name;
        Characters = new List<Character>();
    }
}