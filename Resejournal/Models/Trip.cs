
using SQLite;

namespace Resejournal.Models
{

    [Table("trips")]
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TripDate { get; set; }


    }
}
