using BikeLoan.WebApi.Context;
using BikeLoan.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BikeLoan.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class BikeController : Controller
    {
        private DatabaseContext _dbContext;

        public BikeController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bikes = _dbContext.Bikes.ToList();

            return Ok(bikes);
        }

        [HttpPost]
        public IActionResult Post(IFormFile fileData, [FromForm] Bike bike, int userId)
        {
            using (var stream = new MemoryStream())
            {
                fileData.CopyTo(stream);
                bike.BikeImage = stream.ToArray();
            }

            var userFromDb = _dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (userFromDb == null)
            {
                return BadRequest();
            }

            userFromDb.Bikes.Add(bike);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bike = _dbContext.Bikes.FirstOrDefault(x => x.Id == id);

            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var bike = await _dbContext.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            // Create a MemoryStream from the byte array
            var memoryStream = new MemoryStream(bike.BikeImage);

            // Return the image using the File method
            return File(memoryStream, "image/jpeg");
        }
        [HttpPut]
        public IActionResult Put(IFormFile fileData, [FromForm] Bike bike)
        {
            Bike bikefromdb = _dbContext.Bikes.Where(x => x.Id == bike.Id).FirstOrDefault();
            if(bikefromdb == null)
            {
                return NotFound();
            }
            using (var stream = new MemoryStream())
            {
                fileData.CopyTo(stream);
                bike.BikeImage = stream.ToArray();
            }

            bikefromdb.BikeImage = bike.BikeImage;
            bikefromdb.Name = bike.Name;
            bikefromdb.Distance = bike.Distance;

            _dbContext.Bikes.Update(bikefromdb);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Bike bikefromdb = _dbContext.Bikes.Where(x => x.Id == id).FirstOrDefault();
            if(bikefromdb == null)
            {
                return NotFound();
            }
            _dbContext.Bikes.Remove(bikefromdb);
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}