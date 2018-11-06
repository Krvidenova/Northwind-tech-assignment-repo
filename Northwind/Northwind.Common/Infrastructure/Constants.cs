namespace Northwind.Common.Infrastructure
{
    public class Constants
    {
        public const string NoCustomersMsg = "There are no customers in the database.";
        public const string CustomerDoesNotExistMsg = "Customer with ID {0} does not exist.";
        public const string NoOrdersFromCustomerMsg = "There are no orders from Customer with ID {0} in the database.";
        public const string ServerErrorMsg = "An error occurred. Please contact administrator.";

        public const string GetAllCustomersUri = "customers";
        public const string GetCustomerByIdUri = "/customer/{0}";
        public const string GetOrdersByCustomerIdUri = "/customer/{0}/orders";

        public const string DiscontinuedProductMsg = "The order contains discontinued products.";
        public const string InsufficientStockMsg = "The order contains products with insufficient stock.";
    }
}
