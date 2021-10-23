namespace ggGURPS.DTOs.Rolls
{
    public class GetRollsByCharacterIdDTO
    {
        public long Id { get; set; }
        public int Result { get; set; }
        public bool Success { get; set; }
        public int RollIndex { get; set; }

        public GetRollsByCharacterIdDTO(long id, int result, bool success, int rollIndex)
        {
            Id = id;
            Result = result;
            Success = success;
            RollIndex = rollIndex;
        }
    }
}