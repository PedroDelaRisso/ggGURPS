public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public BaseAttributes BaseAttribute { get; set; }
    public int Level { get; set; }

    public Skill() { }
}