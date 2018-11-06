namespace Northwind.Data.Models
{
    using System.Collections.Generic;

    public class Territory
    {
        public Territory()
        {
            this.EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public string Id { get; set; }

        public string TerritoryDescription { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
