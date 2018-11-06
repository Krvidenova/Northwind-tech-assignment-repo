namespace Northwind.WebClient.Services.Order
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AutoMapper;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.WebClient.Infrastructure.ApiClient;
    using Northwind.WebClient.Services.Order.Interfaces;

    public class OrderService : BaseEfService, IOrderService
    {
        public OrderService(NorthwindClient northwindClient, IMapper mapper)
            : base(northwindClient, mapper)
        {
        }

        public async Task<IEnumerable<OrderConciseViewModel>> GetOrdersByCustomerIdAsync(string customerId)
        {
            IEnumerable<OrderConciseViewModel> models = null;
            var response = await this.NorthwindClient
                               .Client
                               .GetAsync(string.Format(Constants.GetOrdersByCustomerIdUri, customerId));
            if (response.IsSuccessStatusCode)
            {
                var orders = await response.Content.ReadAsAsync<IEnumerable<OrderDetailedViewModel>>();
                models = this.Mapper.Map<IEnumerable<OrderConciseViewModel>>(orders);
            }

            return models;
        }       
    }
}
