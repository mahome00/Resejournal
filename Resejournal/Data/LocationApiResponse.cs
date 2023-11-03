namespace Resejournal.Data
{
    public class LocationApiResponse
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public long Timestamp { get; set; }
        public List<LocationData> Data { get; set; }
    }
}
