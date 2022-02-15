using System.Collections.Generic;

public class Skill
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SpentPoints { get; set; }
    public Difficulty Difficulty { get; set; }
    public BaseAttribute BaseAttribute { get; set; }
    public int Level { get; set; }
    public ICollection<Character> Characters { get; set; }
}