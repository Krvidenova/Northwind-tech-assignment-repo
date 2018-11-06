namespace Northwind.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.WebAPI.Services.Customer.Interfaces;

    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {        
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<CustomerListingViewModel>> GetAll()
        {
            var customers = this.customerService.GetAll();
            if (customers == null)
            {
                return this.NotFound(new { Message = Constants.NoCustomersMsg });
            }

            return customers.ToList();
        }

        [HttpGet("/customer/{id}")]
        public ActionResult<CustomerListingViewModel> GetById(string id)
        {
            var customer = this.customerService.GetById(id);
            if (customer == null)
            {
                return this.NotFound(new { Message = string.Format(Constants.CustomerDoesNotExistMsg, id) });
            }

            return customer;
        }        
    }
}
