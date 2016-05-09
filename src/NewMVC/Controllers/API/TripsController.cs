using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NewMVC.Models;
using AutoMapper;
using NewMVC.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewMVC.Controllers.API
{
    [Route("api/[controller]")]
    public class TripsController : Controller
    {
        private TripContext db = new TripContext();
        private TripsRepository tRepos;

        // GET api/values/5
        [HttpGet]
        public JsonResult Get()
        {
            var trips = db.Trips;
            var result = Mapper.Map<IEnumerable<TripViewModel>>(trips);
            return Json(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Trip ts = tRepos.GetTrip(id);
            return ts.Name;
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]TripViewModel trips)
        {
            var newTrip = Mapper.Map<Trip>(trips);
            newTrip.UserName = "User 1";
            tRepos.AddTrip(newTrip);
            var Trp1 = Mapper.Map<TripViewModel>(newTrip);
            return Json(Trp1);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
