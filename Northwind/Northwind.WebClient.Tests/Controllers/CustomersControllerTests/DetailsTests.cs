namespace Northwind.WebClient.Tests.Controllers.CustomersControllerTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Northwind.Common.Infrastructure;
    using Northwind.Common.Models.Customer.ViewModels;
    using Northwind.WebClient.Controllers;
    using Northwind.WebClient.Services.Customer.Interfaces;

    [TestClass]
    public class DetailsTests
    {
        private readonly CustomerDetailsViewModel customerModel;

        public DetailsTests()
        {
            this.customerModel = new CustomerDetailsViewModel()
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
                OrdersCount = 1
            };
        }

        [TestMethod]
        public async Task Details_WithExistingCustomerId_ReturnsCustomer()
        {
            // Arrange           
            bool methodCalled = false;

            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetByIdAsync(this.customerModel.Id))
                .ReturnsAsync(this.customerModel)
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = await controller.Details(this.customerModel.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(CustomerDetailsViewModel));
            var resultModel = resultView.Model as CustomerDetailsViewModel;
            Assert.AreEqual(this.customerModel.Id, resultModel.Id);
            Assert.IsTrue(methodCalled);
        }

        [TestMethod]
        public async Task Details_WithNotExistingCustomerId_ReturnsErrorMsg()
        {
            // Arrange         
            bool methodCalled = false;
            string notExistingCustomerId = "ALF";
            CustomerDetailsViewModel model = null;
            var mockRepository = new Mock<ICustomerService>();
            mockRepository
                .Setup(service => service.GetByIdAsync(notExistingCustomerId))
                .ReturnsAsync(model)
                .Callback(() => methodCalled = true);

            var controller = new CustomersController(mockRepository.Object);

            // Act
            var result = await controller.Details(notExistingCustomerId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultView = result as ViewResult;
            Assert.IsNotNull(resultView.Model);
            Assert.IsInstanceOfType(resultView.Model, typeof(CustomerDetailsViewModel));
            var resultModel = resultView.Model as CustomerDetailsViewModel;
            Assert.IsNull(resultModel.Id);
            ModelStateDictionary modelState = resultView.ViewData.ModelState;
            Assert.IsFalse(modelState.IsValid);
            Assert.IsTrue(modelState.ErrorCount == 1);
            var modelError = modelState.Values.First().Errors.ToList().First();          
            string error = modelError.ErrorMessage;
            Assert.AreEqual(error, string.Format(Constants.CustomerDoesNotExistMsg, notExistingCustomerId));
            Assert.IsTrue(methodCalled);
        }
    }
}
