namespace Northwind.WebAPI.Tests.Controllers.CustomersControllerTests
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.Common.Models.Order.ViewModels;
    using Northwind.WebAPI.Controllers;
    using Northwind.WebAPI.Services.Customer.Interfaces;

    [TestClass]
    public class GetByIdTests
    {
        private readonly CustomerListingViewModel customerModel;

        public GetByIdTests()
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
        public void GetById_WithExistingCustomerId_ReturnsCustomer()
        {
            // Arrange           
            bool methodCalled = false;

            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetById(this.customerModel.Id))
                .Returns(this.customerModel)
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = controller.GetById(this.customerModel.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<CustomerListingViewModel>));
            var customer = result.Value;
            Assert.IsNotNull(customer);
            Assert.IsInstanceOfType(customer, typeof(CustomerListingViewModel));
            Assert.AreEqual(this.customerModel.Id, customer.Id);
            Assert.IsTrue(methodCalled);
        }

        [TestMethod]
        public void GetById_WithNotExistingCustomerId_ReturnsNotFoundResult()
        {
            // Arrange         
            bool methodCalled = false;
            string notExistingCustomerId = "ALF";
            CustomerListingViewModel model = null;
            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetById(notExistingCustomerId))
                .Returns(model)
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = controller.GetById(notExistingCustomerId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<CustomerListingViewModel>));
            Assert.IsNull(result.Value);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
            var objectResult = result.Result as NotFoundObjectResult;
            Assert.IsTrue(objectResult.StatusCode.Value == 404);
            object resultContent = objectResult.Value;
            Assert.IsNotNull(resultContent);
            var propertyInfo = resultContent.GetType().GetProperty("Message");
            string msg = (string)propertyInfo.GetValue(resultContent, null);
            Assert.AreEqual(msg, string.Format(Constants.CustomerDoesNotExistMsg, notExistingCustomerId));
            Assert.IsTrue(methodCalled);
        }
    }
}
