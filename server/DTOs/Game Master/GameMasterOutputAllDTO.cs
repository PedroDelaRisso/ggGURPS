public class GameMasterOutputAllDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public GameMasterOutputAllDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}