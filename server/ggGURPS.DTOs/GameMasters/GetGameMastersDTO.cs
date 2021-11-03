public class GetGameMastersDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public GetGameMastersDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}