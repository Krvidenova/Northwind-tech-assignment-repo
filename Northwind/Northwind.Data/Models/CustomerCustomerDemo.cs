namespace Northwind.Data.Models
{
    public class CustomerCustomerDemo
    {
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string CustomerTypeId { get; set; }        

        public CustomerDemographics CustomerType { get; set; }
    }
}
