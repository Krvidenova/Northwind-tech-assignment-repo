namespace Northwind.WebClient.Services.Order.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Northwind.Common.Models.Order.ViewModels;

    public interface IOrderService
    {
        Task<IEnumerable<OrderConciseViewModel>> GetOrdersByCustomerIdAsync(string customerId);
    }
}