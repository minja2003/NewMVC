using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMVC.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public ICollection<Stop> Stops{ get; set; }

    }
}
