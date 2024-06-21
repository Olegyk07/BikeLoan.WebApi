using BikeLoan.WebApi.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BikeLoan.WebApi.Models;
using BikeLoan.WebApi.Requests;

namespace BikeLoan.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private DatabaseContext _dbContext;

        public UsersController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Users user)
        {
            Users usersfromdb = _dbContext.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (usersfromdb == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(usersfromdb);
            }
        }
        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody] Users user)
        {
            Users usersfromdb = _dbContext.Users.Where(x => x.Username == user.Username || x.Email == user.Email || x.TelNumber == user.TelNumber).FirstOrDefault();

            if (usersfromdb != null)
            {
                return BadRequest();
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Users usersfromdb = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (usersfromdb == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(usersfromdb);
            _dbContext.SaveChanges();
            return Ok();
            
        }
        [HttpGet("list")]
        public IActionResult Get()
        {
            List<Users> usersfromdb = _dbContext.Users.ToList();

            return Ok(usersfromdb);
        }
        [HttpPost("orders")]
        public IActionResult Order([FromBody] OrderRequest request)
        {
            Orders order = new Orders() 
            {
                OrderDate = DateTime.Now,
                CustomerId = request.CustomerId,
                BikeId = request.BikeId
            };

            _dbContext.Add(order);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}