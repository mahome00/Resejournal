using Resejournal.Models;
using SQLite;

namespace Resejournal.Services
{
    public class TripService
    {

        private SQLiteConnection conn;
        string _dbPath;
        public string StateMessage;
        int result = 0;
        public TripService(string dbPath)
        {
            _dbPath = dbPath;
        }
        private void Init()

        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Trip>();
            conn.CreateTable<TripPhoto>();
        }
        public List<Trip> GetTrips()
        {

            try
            {
                Init();
                return conn.Table<Trip>().ToList();

            }
            catch (Exception)
            {
                StateMessage = "Unable to fetch data";

                throw;
            }
            return new List<Trip>();

        }

        public void AddTrip(Trip trip)
        {
            try
            {
                Init();

                if (trip == null)
                    throw new Exception("The trip entry is not valid");

                result = conn.Insert(trip);
                StateMessage = result == 0 ? "Failed to add the trip to the database" : "Trip added successfully to the database";
            }
            catch (Exception)
            {
                StateMessage = "Unable to save the trip data";
                throw;
            }
        }

        public void AddPhoto(TripPhoto photo)
        {
            try
            {
                Init();
                if (photo == null)
                    throw new Exception("The photo entry is not valid");
                conn.Insert(photo);
            }
            catch (Exception)
            {
                StateMessage = "Unable to save the photo data";
                throw;
            }
        }

        public List<TripPhoto> GetPhotosForTrip(int tripId)
        {
            try
            {
                Init();
                return conn.Table<TripPhoto>().Where(p => p.TripID == tripId).ToList();
            }
            catch (Exception)
            {
                StateMessage = "Unable to fetch photos";
                throw;
            }
        }
    }
}
