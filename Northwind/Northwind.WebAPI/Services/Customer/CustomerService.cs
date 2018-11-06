namespace Northwind.WebAPI.Services.Customer
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.Data;
    using Northwind.WebAPI.Services.Customer.Interfaces;

    public class CustomerService : BaseEfService, ICustomerService
    {
        public CustomerService(NorthwindDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IEnumerable<CustomerListingViewModel> GetAll()
        {
            var customers = this.Context.Customers
                                .Include(c => c.Orders).ThenInclude(o => o.Employee)
                                .Include(c => c.Orders).ThenInclude(o => o.ShipViaNavigation)
                                .ToList();
            var models = this.Mapper.Map<ICollection<CustomerListingViewModel>>(customers);
            return models;
        }

        public CustomerListingViewModel GetById(string id)
        {
            var customer = this.Context.Customers
                               .Include(c => c.Orders).ThenInclude(o => o.Employee)
                               .Include(c => c.Orders).ThenInclude(o => o.ShipViaNavigation)
                               .FirstOrDefault(c => c.Id == id);
            var model = this.Mapper.Map<CustomerListingViewModel>(customer);
            return model;
        }

        public bool CheckIfCustomerExists(string id)
        {
            return this.Context.Customers.Any(c => c.Id == id);
        }
    }
}