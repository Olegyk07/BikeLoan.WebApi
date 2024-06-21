using BikeLoan.WebApi.Context;
using BikeLoan.WebApi.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeLoan.WebApi.Controllers
{
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private DatabaseContext _dbContext;

        public OrderController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetOrderDetails(int id)
        {
            var order = _dbContext.Orders
                .Include(x => x.Customer)
                .Include(x => x.Bike)
                .FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var response = new OrderDetailsResponse
            {
               OrderDate = order.OrderDate,
               UserFullName = order.Customer.FirstName + " " + order.Customer.LastName,
               OrderId = order.Id,
               UserEmail = order.Customer.Email,
               UserPhoneNumber = order.Customer.TelNumber,
               BikeId = order.Bike.Id,
               BikeName = order.Bike.Name
            };
            return Ok(response);
        }
    }
}
