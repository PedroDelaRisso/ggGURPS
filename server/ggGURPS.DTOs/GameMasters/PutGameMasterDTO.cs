public class PutGameMasterDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public PutGameMasterDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}