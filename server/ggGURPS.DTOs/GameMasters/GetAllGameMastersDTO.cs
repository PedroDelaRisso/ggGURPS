namespace ggGURPS.DTOs.GameMasters
{
    public class GetAllGameMastersDTO
    {
        long Id;
        string Name;

        public GetAllGameMastersDTO(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}