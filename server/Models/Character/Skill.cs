public class Skill
{
    public long Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public int Level { get; set; }
    public BaseAttribute Attribute { get; set; }
}