﻿namespace Northwind.Data.Models
{
    public class EmployeeTerritory
    {
        public int EmployeeId { get; set; }
       
        public Employee Employee { get; set; }

        public string TerritoryId { get; set; }

        public Territory Territory { get; set; }
    }
}
