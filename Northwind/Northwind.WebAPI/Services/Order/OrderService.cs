namespace Northwind.WebAPI.Services.Order
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.Data;
    using Northwind.WebAPI.Services.Order.Interfaces;

    public class OrderService : BaseEfService, IOrderService
    {
        public OrderService(NorthwindDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IEnumerable<OrderDetailedViewModel> GetOrdersByCustomerId(string customerId)
        {
            var orders = this.Context.Orders
                             .Include(o => o.Customer)
                             .Include(o => o.Employee)
                             .Include(o => o.ShipViaNavigation)
                             .Include(o => o.OrderDetails)
                             .ThenInclude(od => od.Product)
                             .Where(o => o.CustomerId == customerId)
                             .ToList();
            var models = this.Mapper.Map<ICollection<OrderDetailedViewModel>>(orders);
            return models;
        }
    }
}
