using Resejournal.Models;

namespace Resejournal.Services
{
    public class TripService
    {

        public List<Trip> GetTrips()
        {
            return new List<Trip>()
            {
                new Trip()
                {
                    Id = 1, Title="Tokyo", TripDate= DateTime.Now
                },
                new Trip()
                {
                    Id = 2, Title="Madrid", TripDate= new DateTime(2023, 12, 12)
                },
                   new Trip()
                {
                    Id = 3, Title="London", TripDate= new DateTime(2024,07,01)
                }

            };
        }
    }
}
