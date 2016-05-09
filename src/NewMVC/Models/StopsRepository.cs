using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMVC.Models
{
    public class StopsRepository
    {
        private TripContext dbContext;

       
        public StopsRepository(TripContext D)
        {
            dbContext = D;
        }

        public IEnumerable<Stop> Get(string tripN)
        {
            var trips = dbContext.Trips.Include(a => a.Stops).Where(a => a.Name == tripN).Single();
            return trips.Stops;
        }

        public Trip AddTrip(Stop stop, Trip trip)
        {
            trip.Stops.Add(stop);
            dbContext.Trips.Update(trip);
            dbContext.SaveChanges();

            return trip;
        }
    }
}
