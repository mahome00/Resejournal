namespace Resejournal.Data
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public long Timestamp { get; set; }
        public ApiData Data { get; set; }
    }
}
