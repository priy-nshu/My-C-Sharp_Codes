using NUnit.Framework;

namespace NUnitForCustomerOrderService
{
    [TestFixture]
    public class CustomerOrderServiceTest
    {
        public CustomerOrderSvc cost;
        [SetUp]
        public void Initialize()
        {
            cost = new CustomerOrderSvc();
        }
        [TestCase]
        public void When_GetOrder_Expect_5Orders()
        {
            List<Order> ord = cost.GetOrders();
            //Assert.That(ord.Count(), Is.Not.Null);
            Assert.That(ord.Count, Is.EqualTo(5));
        }
        [TestCase]
        public void OrderById_Test()
        {
            CustomerOrderSvc svc = new CustomerOrderSvc();
            Order ord = svc.GetOrderById(1);
            Assert.That(ord, Is.Not.Null);
            Assert.That(1, Is.EqualTo(ord.OrderId));

        }
        [TestCase]
        public void OrdersByProductId_Test()
        {
            CustomerOrderSvc svc = new CustomerOrderSvc();
            var orders = svc.GetOrdersByProductId(43);

            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.All(o => o.ProductId == 43));
        }

    }
}
