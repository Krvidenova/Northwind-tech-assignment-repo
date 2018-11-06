namespace Northwind.Common.Models.Order.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class OrderDetailedViewModel
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int? EmployeeId { get; set; }
        
        public string EmployeeName { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipperId { get; set; }
        
        public string ShipViaShipperName { get; set; }

        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public ICollection<OrderDetailsViewModel> OrderDetails { get; set; } = new List<OrderDetailsViewModel>();
    }
}
