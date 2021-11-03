public class GetRollsDTO
{
    public long Id { get; set; }
    public int FinalResult { get; set; }
    public GetRollsDTO(long id, int finalResult)
    {
        Id = id;
        FinalResult = finalResult;
    }
}