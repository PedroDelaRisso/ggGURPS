public class GameMasterOutputPostDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public GameMasterOutputPostDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}