namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            this.CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
