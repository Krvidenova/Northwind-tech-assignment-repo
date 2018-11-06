namespace Northwind.WebAPI.Services.Customer.Interfaces
{
    using System.Collections.Generic;
    using Northwind.Common.Models.Customer.ViewModels;

    public interface ICustomerService
    {
        IEnumerable<CustomerListingViewModel> GetAll();

        CustomerListingViewModel GetById(string id);

        bool CheckIfCustomerExists(string id);
    }
}