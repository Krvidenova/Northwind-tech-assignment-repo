namespace Northwind.WebAPI.Tests.Controllers.CustomersControllerTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.WebAPI.Controllers;
    using Northwind.WebAPI.Services.Customer.Interfaces;

    [TestClass]
    public class GetAllTests
    {
        private readonly CustomerListingViewModel customerModel;

        public GetAllTests()
        {
            this.customerModel = new CustomerListingViewModel()
            {
                Id = "PARIS",
                ContactName = "Marie Bertrand",
                CompanyName = "Paris spécialités",
                ContactTitle = "Owner",
                Address = "265, boulevard Charonne",
                City = "Paris",
                Region = null,
                PostalCode = "75012",
                Country = "France",
                Phone = "(1) 42.34.22.66",
                Fax = "(1) 42.34.22.77",
                Orders = new List<OrderListingViewModel>()
            };
        }

        [TestMethod]
        public void GetAll_WithExistingCustomers_ReturnsAllCustomers()
        {
            // Arrange           
            bool methodCalled = false;

            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetAll())
                .Returns(new[] { this.customerModel })
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<CustomerListingViewModel>>));
            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value.Count() == 1);
            Assert.IsTrue(methodCalled);
        }

        [TestMethod]
        public void GetAll_WithZeroCustomers_ReturnsNotFoundResult()
        {
            // Arrange         
            bool methodCalled = false;
            List<CustomerListingViewModel> models = null;
            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetAll())
                .Returns(models)
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<CustomerListingViewModel>>));
            Assert.IsNull(result.Value);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
            var objectResult = result.Result as NotFoundObjectResult;
            Assert.IsTrue(objectResult.StatusCode.Value == 404);
            object resultContent = objectResult.Value;
            Assert.IsNotNull(resultContent);
            var propertyInfo = resultContent.GetType().GetProperty("Message");
            string msg = (string)propertyInfo.GetValue(resultContent, null);
            Assert.AreEqual(msg, Constants.NoCustomersMsg);
            Assert.IsTrue(methodCalled);
        }      
    }
}
