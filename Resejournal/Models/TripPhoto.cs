namespace Resejournal.Models
{
    public class TripPhoto
    {

        public int Id { get; set; }
        public int TripID { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
    }
}
