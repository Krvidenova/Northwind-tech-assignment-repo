namespace Northwind.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int? EmployeeId { get; set; }
        
        public Employee Employee { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }
        
        public Shipper ShipViaNavigation { get; set; }

        public decimal? Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
