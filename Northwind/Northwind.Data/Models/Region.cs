namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }

        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }
    }
}
