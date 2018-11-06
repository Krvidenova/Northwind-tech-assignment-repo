namespace Northwind.Common.Models.Order.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; }
    }
}
