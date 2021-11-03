public class PostPlayerDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public PostPlayerDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}