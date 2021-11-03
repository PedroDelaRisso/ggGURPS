using System.Collections.Generic;

public class GameMaster
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Campaign> Campaigns { get; set; }
    public ICollection<Roll> Rolls { get; set; }

    public GameMaster(long id, string name)
    {
        Id = id;
        Name = name;
        Campaigns = new List<Campaign>();
        Rolls = new List<Roll>();
    }
}
