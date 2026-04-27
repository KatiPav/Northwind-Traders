using Fourth_Technical_Assesment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace Fourth.Tests;

[TestClass]
public sealed class CustomerServiceTests
{

    private FourthContext _context;
    private CustomerService _customerService;

    [TestInitialize]
    public async Task Setup()
    {

        var logger = NullLogger<CustomerService>.Instance;
        var options = new DbContextOptionsBuilder<FourthContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new FourthContext(options);


        OrderDetail orderDetail = new OrderDetail
        {
            OrderId = 11,
            ProductId = 115,
            UnitPrice = 1,
            Quantity = 2,
            Discount = 0.5f
        };
        OrderDetail orderDetail2 = new OrderDetail
        {
            OrderId = 11,
            ProductId = 114,
            UnitPrice = 1,
            Quantity = 2,
            Discount = 0.5f
        };
        OrderDetail orderDetail3 = new OrderDetail
        {
            OrderId = 22,
            ProductId = 122,
            UnitPrice = 1,
            Quantity = 2,
            Discount = 0.5f
        };
        OrderDetail orderDetail4 = new OrderDetail
        {
            OrderId = 12,
            ProductId = 123,
            UnitPrice = 1,
            Quantity = 2,
            Discount = 0.5f
        };

        Order order = new Order
        {
            CustomerId = "1",
            OrderId = 11,
            OrderDate = new DateTime(),
            OrderDetails = new List<OrderDetail>() { orderDetail, orderDetail2 }
        };

        Order order2 = new Order
        {
            CustomerId = "1",
            OrderId = 12,
            OrderDate = new DateTime(),
            OrderDetails = new List<OrderDetail>() { orderDetail3, orderDetail4 }
        };
        _context.Orders.AddRange(
            order, order2
        );

        _context.Customers.AddRange(
            new Customer { CustomerId = "1", CompanyName = "Alpha Ltd", Orders = new List<Order>() { order, order2 } },
            new Customer { CustomerId = "2", CompanyName = "Beta Ltd", Orders = new List<Order>() }
        );

        await _context.SaveChangesAsync();
        _customerService = new CustomerService(_context, logger);
    }


    [TestMethod]
    public async Task GetCustomers_FiltersByName()
    {
        var result = await _customerService.GetCustomers("Beta");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Beta Ltd", result[0].CompanyName);
    }

    [TestMethod]
    public async Task GetCustomers_ReturnsAllCustomers()
    {
        var result = await _customerService.GetCustomers();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Alpha Ltd", result[0].CompanyName);
    }

    [TestMethod]
    public async Task GetCustomerDetailsById_ReturnsCustomerDetails()
    {
        CustomerDetailsDto details = await _customerService.GetCustomerDetailsById("1");

        Assert.AreEqual(2, details?.OrderHistory?.Count);
        Assert.AreEqual(2, details?.OrderHistory?[0].TotalValue);
        Assert.AreEqual(2, details?.OrderHistory?[0].ProductCount);
    }

    [TestMethod]
    public async Task GetCustomerDetailsById_ThrowsIfIdNotFound()
    {
        await Assert.ThrowsAsync<KeyNotFoundException>(async () => await _customerService.GetCustomerDetailsById("fake"));
    }
}
