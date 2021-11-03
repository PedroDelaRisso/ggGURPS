public class GetPlayersDTO
{
    public long Id { get; set; }
    public string Name { get; set; }

    public GetPlayersDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}