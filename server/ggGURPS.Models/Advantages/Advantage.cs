using System.Collections.Generic;
public class Advantage
{
    public long Id { get; set; }
    public int Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<CharacterAdvantage> Characters { get; set; }

    public Advantage()
    {
        Characters = new List<CharacterAdvantage>();
    }
}