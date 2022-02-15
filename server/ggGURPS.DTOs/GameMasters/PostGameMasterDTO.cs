public class PostGameMasterDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public PostGameMasterDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}