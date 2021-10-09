public class GameMasterOutputDeleteDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public GameMasterOutputDeleteDTO(long id, string name)
    {
        Id = id;
        Name = name;
    }
}