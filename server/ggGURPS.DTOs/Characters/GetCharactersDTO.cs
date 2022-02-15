public class GetCharactersDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public GetCharactersDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}