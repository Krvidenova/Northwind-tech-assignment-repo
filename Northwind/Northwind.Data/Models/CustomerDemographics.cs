namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class CustomerDemographics
    {
        public CustomerDemographics()
        {
            this.CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }

        public string CustomerDesc { get; set; }

        public ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    }
}
