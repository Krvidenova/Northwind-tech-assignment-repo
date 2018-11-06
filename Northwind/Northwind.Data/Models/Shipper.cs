namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class Shipper
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
