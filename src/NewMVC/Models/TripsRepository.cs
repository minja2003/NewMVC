using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace NewMVC.Models
{
    public class TripsRepository
    {
        private TripContext dbContext;

        public TripsRepository(TripContext D)
        {
            dbContext = D;
        }
        public IEnumerable<Trip> GetAllTrips()
        {
            var Tr = dbContext.Trips.Include(a => a.Stops);
            return Tr;
        }

        public Trip GetTrip(int id)
        {
            var Trs = dbContext.Trips.Where(a => a.TripID == id).Single();
            return (Trs);
        }

        public void AddTrip(Trip trip)
        {
            dbContext.Add(trip);
            
        }
    }
   
}
