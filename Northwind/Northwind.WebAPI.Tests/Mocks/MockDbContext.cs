namespace Northwind.WebAPI.Tests.Mocks
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Northwind.Data;
    
    // The mock of the DbContext will be used to test the services.
    public static class MockDbContext
    {
        public static NorthwindDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<NorthwindDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new NorthwindDbContext(options);
        }
    }
}
