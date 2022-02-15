using System.Collections.Generic;

public class GameMaster
{
    public long Id { get; set; }

    public string Name { get; set; }

    public ICollection<Character> Characters { get; set; }

    public GameMaster(string name)
    {
        Name = name;
        Characters = new List<Character>();
    }
}