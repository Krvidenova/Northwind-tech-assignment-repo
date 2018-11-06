namespace Northwind.WebClient.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.WebClient.Services.Customer.Interfaces;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var customer = await this.customerService.GetByIdAsync(id);
            if (customer == null)
            {
                this.ModelState.AddModelError(string.Empty, string.Format(Constants.CustomerDoesNotExistMsg, id));
                customer = new CustomerDetailsViewModel();
            }

            return this.View(customer);
        }
    }
}