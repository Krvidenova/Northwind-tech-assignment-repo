namespace Northwind.WebClient.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.WebClient.Services.Customer.Interfaces;
    using Northwind.WebClient.Services.Order.Interfaces;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;

        public OrdersController(IOrderService orderService, ICustomerService customerService)
        {
            this.orderService = orderService;
            this.customerService = customerService;
        }

        public async Task<IActionResult> LoadOrders(string customerId)
        {
            var customerExists = await this.customerService.CheckIfCustomerExists(customerId);
            if (!customerExists)
            {
                this.ModelState.AddModelError(string.Empty, string.Format(Constants.CustomerDoesNotExistMsg, customerId));
                return this.PartialView("_LoadOrders", new List<OrderConciseViewModel>());
            }

            var orders = await this.orderService.GetOrdersByCustomerIdAsync(customerId);
            if (orders == null)
            {
                this.ModelState.AddModelError(string.Empty, Constants.ServerErrorMsg);
                orders = new List<OrderConciseViewModel>();
            }

            return this.PartialView("_LoadOrders", orders);
        }
    }
}