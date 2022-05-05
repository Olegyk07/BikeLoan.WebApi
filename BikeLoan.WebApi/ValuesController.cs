namespace BikeLoan.WebApi.Controllers
{
    using BikeLoan.WebApi.Context;
    using BikeLoan.WebApi.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private BikeContext _bikesContext;

        public BikeController(BikeContext bikeContext)
        {
            _bikesContext = bikeContext;
        }

        [HttpGet]
        public IEnumerable<Bike> Get()
        {
            return _bikesContext.Bikes;
        }

        [HttpGet("{id}")]
        public Bike Get(int id)
        {
            return _bikesContext.Bikes.FirstOrDefault(s => s.BikeID == id);
        }
        [HttpPost]
        public void Post([FromBody] Bike value)
        {
            _bikesContext.Bikes.Add(value);
            _bikesContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bike value)
        {
            var employee = _bikesContext.Bikes.FirstOrDefault(s => s.BikeID == id);
            if (employee != null)
            {
                _bikesContext.Entry<Bike>(employee).CurrentValues.SetValues(value);
                _bikesContext.SaveChanges();
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _bikesContext.Bikes.FirstOrDefault(s => s.BikeID == id);
            if (student != null)
            {
                _bikesContext.Bikes.Remove(student);
                _bikesContext.SaveChanges();
            }
        }
    }
}
