namespace Northwind.WebAPI.Services.Order.Interfaces
{
    using System.Collections.Generic;
    using Northwind.Common.Models.Order.ViewModels;

    public interface IOrderService
    {
        IEnumerable<OrderDetailedViewModel> GetOrdersByCustomerId(string customerId);
    }
}