using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NewMVC.Models;
using AutoMapper;
using Microsoft.Data.Entity;
using NewMVC.ViewModels;
using NewMVC.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewMVC.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        private TripContext db = new TripContext();
        private StopsRepository tRepos;
        private CoordinateService cordS;

        public StopsController(TripContext tp, CoordinateService s)
        {
            db = tp;
            cordS = s;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get(string tripName)
        {
            var stops = db.Trips.Include(a => a.Stops).Where(a => a.Name == tripName);
            var results = Mapper.Map<IEnumerable<StopViewModel>>(stops);
            return Json(results);
        }

        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]Trip trip, Stop stop)
        {
            var tripA = Mapper.Map<Trip>(trip);
            var stopA = Mapper.Map<Stop>(stop);

            var longlat = await cordS.Lookup(stopA.Name);
            tripA.Stops.Add(stopA);
            if (ModelState.IsValid)
            {
                db.Trips.Update(tripA);
                db.SaveChanges();
            }


            var result = Mapper.Map<TripViewModel>(tripA);
            return Json(result);
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
