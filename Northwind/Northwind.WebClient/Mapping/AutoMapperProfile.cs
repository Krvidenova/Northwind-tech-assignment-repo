namespace Northwind.WebClient.Mapping
{
    using System.Linq;
    using AutoMapper;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.Common.Models.Order.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<CustomerListingViewModel, CustomerConciseViewModel>()
                .ForMember(
                    viewModel => viewModel.OrdersCount,
                    opt => opt.MapFrom(c => c.Orders.Count))
                .ForMember(
                    viewModel => viewModel.No,
                    opt => opt.Ignore());

            this.CreateMap<CustomerListingViewModel, CustomerDetailsViewModel>()
                .ForMember(
                    viewModel => viewModel.OrdersCount,
                    opt => opt.MapFrom(c => c.Orders.Count));

            this.CreateMap<OrderDetailedViewModel, OrderConciseViewModel>()                
                .ForMember(
                    viewModel => viewModel.ProductsCount,
                    opt => opt.MapFrom(o => o.OrderDetails.Sum(od => od.Quantity)))
                .ForMember(
                    viewModel => viewModel.TotalAmount,
                    opt => opt.MapFrom(
                        o => o.OrderDetails.Sum(
                            od => (od.UnitPrice * od.Quantity) - (od.UnitPrice * od.Quantity * (decimal)od.Discount))))
                .ForMember(
                    viewModel => viewModel.DiscontinuedProduct,
                    opt => opt.MapFrom(
                        o => o.OrderDetails.Any(od => od.Discontinued == true) ? Constants.DiscontinuedProductMsg : null))
                .ForMember(
                    viewModel => viewModel.InsufficientStock,
                    opt => opt.MapFrom(
                        o => o.OrderDetails.Any(od => od.UnitsInStock < od.UnitsOnOrder) ? Constants.InsufficientStockMsg : null));            
        }
    }
}