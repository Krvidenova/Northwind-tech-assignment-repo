namespace Northwind.WebClient.Services.Customer.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Northwind.Common.Models.Customer.ViewModels;

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerConciseViewModel>> GetAllAsync();

        Task<IEnumerable<CustomerConciseViewModel>> GetByNameAsync(string name);

        Task<CustomerDetailsViewModel> GetByIdAsync(string id);

        Task<bool> CheckIfCustomerExists(string id);
    }
}