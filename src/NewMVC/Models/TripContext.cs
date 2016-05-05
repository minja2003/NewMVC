using System;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMVC.Models 
{

    public class TripContext : DbContext
    {
        public Microsoft.Data.Entity.DbSet<NewMVC.Models.Stop> Stops { get; set; }

        public Microsoft.Data.Entity.DbSet<NewMVC.Models.Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString =
               Startup.Configuration["Data:DefaultConnection:TripsConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
        public TripContext()
        {
            Database.EnsureCreated();
        }


    }
}
