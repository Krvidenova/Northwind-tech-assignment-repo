namespace Northwind.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.WebAPI.Services.Customer.Interfaces;
    using Northwind.WebAPI.Services.Order.Interfaces;

    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;

        public OrdersController(ICustomerService customerService, IOrderService orderService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
        }

        [HttpGet("/customer/{id}/orders")]
        public ActionResult<IEnumerable<OrderDetailedViewModel>> GetOrdersByCustomerId(string id)
        {
            var customerExists = this.customerService.CheckIfCustomerExists(id);
            if (!customerExists)
            {
                return this.NotFound(new { Message = string.Format(Constants.CustomerDoesNotExistMsg, id) });
            }

            var orders = this.orderService.GetOrdersByCustomerId(id);
            if (orders == null)
            {
                return this.NotFound(new { Message = string.Format(Constants.NoOrdersFromCustomerMsg, id) });
            }

            return orders.ToList();
        }
    }
}