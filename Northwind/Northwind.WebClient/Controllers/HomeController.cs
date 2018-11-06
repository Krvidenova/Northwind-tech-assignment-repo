namespace Northwind.WebClient.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.WebClient.Services.Customer.Interfaces;

    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;

        public HomeController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await this.customerService.GetAllAsync();
            if (customers == null)
            {
                this.ModelState.AddModelError(string.Empty, Constants.ServerErrorMsg);
                customers = new List<CustomerConciseViewModel>();
            }

            return this.View(customers);
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            IEnumerable<CustomerConciseViewModel> customers = null;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                customers = await this.customerService.GetAllAsync();
                if (customers == null)
                {
                    this.ModelState.AddModelError(string.Empty, Constants.ServerErrorMsg);
                    customers = new List<CustomerConciseViewModel>();
                }

                return this.PartialView("_CustomerList", customers);
            }

            customers = await this.customerService.GetByNameAsync(searchTerm);
            if (customers == null)
            {
                this.ModelState.AddModelError(string.Empty, Constants.ServerErrorMsg);
                customers = new List<CustomerConciseViewModel>();
            }

            return this.PartialView("_CustomerList", customers);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
