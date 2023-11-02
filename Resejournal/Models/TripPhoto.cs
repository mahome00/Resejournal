using SQLite;

namespace Resejournal.Models
{

    [Table("photos")]
    public class TripPhoto
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int TripID { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
    }
}
