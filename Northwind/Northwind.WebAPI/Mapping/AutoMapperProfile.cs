namespace Northwind.WebAPI.Mapping
{
    using AutoMapper;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.Data.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Customer, CustomerListingViewModel>();

            this.CreateMap<Order, OrderListingViewModel>()
                .ForMember(
                    viewModel => viewModel.CustomerName,
                    opt => opt.MapFrom(order => order.Customer.ContactName))
                .ForMember(
                    viewModel => viewModel.EmployeeName,
                    opt => opt.MapFrom(order => string.Concat(order.Employee.FirstName, " ", order.Employee.LastName)))
                .ForMember(
                    viewModel => viewModel.ShipperId,
                    opt => opt.MapFrom(order => order.ShipVia))
                .ForMember(
                    viewModel => viewModel.ShipViaShipperName,
                    opt => opt.MapFrom(order => order.ShipViaNavigation.CompanyName));

            this.CreateMap<Order, OrderDetailedViewModel>()
                .ForMember(
                    viewModel => viewModel.CustomerName,
                    opt => opt.MapFrom(order => order.Customer.ContactName))
                .ForMember(
                    viewModel => viewModel.EmployeeName,
                    opt => opt.MapFrom(order => string.Concat(order.Employee.FirstName, " ", order.Employee.LastName)))
                .ForMember(
                    viewModel => viewModel.ShipperId,
                    opt => opt.MapFrom(order => order.ShipVia))
                .ForMember(
                    viewModel => viewModel.ShipViaShipperName,
                    opt => opt.MapFrom(order => order.ShipViaNavigation.CompanyName));

            this.CreateMap<OrderDetails, OrderDetailsViewModel>()
                .ForMember(
                    viewModel => viewModel.ProductName,
                    opt => opt.MapFrom(orderDetails => orderDetails.Product.ProductName))
                .ForMember(
                    viewModel => viewModel.UnitsInStock,
                    opt => opt.MapFrom(orderDetails => orderDetails.Product.UnitsInStock))
                .ForMember(
                    viewModel => viewModel.UnitsOnOrder,
                    opt => opt.MapFrom(orderDetails => orderDetails.Product.UnitsOnOrder))
                .ForMember(
                    viewModel => viewModel.Discontinued,
                    opt => opt.MapFrom(orderDetails => orderDetails.Product.Discontinued));
        }
    }
}
