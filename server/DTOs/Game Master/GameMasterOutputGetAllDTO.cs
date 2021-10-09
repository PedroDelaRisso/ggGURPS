public class GameMasterOutputGetAllDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public GameMasterOutputGetAllDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}