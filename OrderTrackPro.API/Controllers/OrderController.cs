using Microsoft.AspNetCore.Mvc;
using OrderTrackPro.Application.Interfaces;

namespace OrderTrackPro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
       private readonly IOrderInterfaceService _orderInterfaceService;
        public OrderController(IOrderInterfaceService orderInterfaceService)
        {
            _orderInterfaceService = orderInterfaceService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderInterfaceService.GetOrdersAsync();
            return Ok(orders);
        }
    }
}
