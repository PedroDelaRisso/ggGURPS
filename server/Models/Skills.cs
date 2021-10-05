public class Skills
{
    public long Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
    public int Level { get; set; }
    public int Attribute { get; set; } // change to an Enum later
}