namespace Northwind.Common.Models.Order.ViewModels
{
    public class OrderConciseViewModel
    {
        public int Id { get; set; }

        public int ProductsCount { get; set; }

        public decimal TotalAmount { get; set; }

        public string DiscontinuedProduct { get; set; }

        public string InsufficientStock { get; set; }
    }
}
