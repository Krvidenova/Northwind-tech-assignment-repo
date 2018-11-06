namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
