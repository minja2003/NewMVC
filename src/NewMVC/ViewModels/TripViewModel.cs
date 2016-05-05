using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewMVC.ViewModels
{
    public class TripViewModel
    {

        public int TripID { get; set; }
        [Required(ErrorMessage = "Please Enter A Name")]
        [StringLength(255, MinimumLength = 4)]
        public string Name { get; set; }
        public DateTime DateCreated = DateTime.Now;
        public IEnumerable<StopViewModel> stops { get; set; }
    }
}
