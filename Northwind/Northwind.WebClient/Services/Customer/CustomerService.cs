namespace Northwind.WebClient.Services.Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.WebClient.Infrastructure.ApiClient;
    using Northwind.WebClient.Services.Customer.Interfaces;

    public class CustomerService : BaseEfService, ICustomerService
    {
        public CustomerService(NorthwindClient northwindClient, IMapper mapper)
            : base(northwindClient, mapper)
        {
        }

        public async Task<IEnumerable<CustomerConciseViewModel>> GetAllAsync()
        {
            List<CustomerConciseViewModel> models = null;
            var response = await this.NorthwindClient
                               .Client
                               .GetAsync(Constants.GetAllCustomersUri);
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadAsAsync<List<CustomerListingViewModel>>();
                models = this.Mapper
                    .Map<ICollection<CustomerConciseViewModel>>(customers)
                    .OrderBy(c => c.ContactName)
                    .ToList();
                int number = 0;
                foreach (var model in models)
                {
                    model.No = ++number;
                }
            }

            return models;
        }

        public async Task<IEnumerable<CustomerConciseViewModel>> GetByNameAsync(string name)
        {
            List<CustomerConciseViewModel> models = null;
            var response = await this.NorthwindClient
                               .Client
                               .GetAsync(Constants.GetAllCustomersUri);
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadAsAsync<List<CustomerListingViewModel>>();
                models = this.Mapper
                    .Map<ICollection<CustomerConciseViewModel>>(customers)
                    .Where(m => m.ContactName.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                    .OrderBy(c => c.ContactName)
                    .ToList();
                int number = 0;
                foreach (var model in models)
                {
                    model.No = ++number;
                    var replaced = Regex.Replace(
                        model.ContactName,
                        $"({Regex.Escape(name)})",
                        match => $@"<strong class=""text-danger"">{match}</strong>",
                        RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    model.ContactName = replaced;
                }
            }

            return models;
        }

        public async Task<CustomerDetailsViewModel> GetByIdAsync(string id)
        {
            CustomerDetailsViewModel model = null;
            var response = await this.NorthwindClient
                               .Client
                               .GetAsync(string.Format(Constants.GetCustomerByIdUri, id));
            if (response.IsSuccessStatusCode)
            {
                var customer = await response.Content.ReadAsAsync<CustomerListingViewModel>();
                model = this.Mapper.Map<CustomerDetailsViewModel>(customer);
            }

            return model;
        }

        public async Task<bool> CheckIfCustomerExists(string id)
        {
            var customer = await this.GetByIdAsync(id);
            return customer.Id != null;
        }
    }
}
