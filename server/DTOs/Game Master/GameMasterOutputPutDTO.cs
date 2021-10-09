public class GameMasterOutputPutDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public GameMasterOutputPutDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}