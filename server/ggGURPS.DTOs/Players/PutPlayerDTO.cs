public class PutPlayerDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public PutPlayerDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}