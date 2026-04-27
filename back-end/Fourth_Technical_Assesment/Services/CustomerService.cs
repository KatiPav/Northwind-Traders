using Fourth_Technical_Assesment;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Fourth_Technical_Assesment;

public class CustomerService : ICustomerService
{
    FourthContext _context;
    ILogger<CustomerService> _logger;
    public CustomerService(FourthContext dbContext, ILogger<CustomerService> logger)
    {
        _context = dbContext;
        _logger = logger;
    }

    public async Task<CustomerDetailsDto> GetCustomerDetailsById(string id)
    {
        var result = await _context.Customers.Where(c => c.CustomerId == id)
        .Select(c =>
            new CustomerDetailsDto
            {
                OrderHistory = c.Orders.Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipCountry = o.ShipCountry,
                    TotalValue = o.OrderDetails.Sum(od => ((decimal)od.Quantity) * od.UnitPrice * (decimal)(1 - od.Discount)),
                    //here i am unsure if you want the number of unique products or the total number of products. I implemented it with unique.
                    ProductCount = o.OrderDetails.Select(od => od.ProductId).Distinct().Count()
                }).ToList(),

                CustomerId = c.CustomerId,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            }
        ).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Customer with id '{id}' was not found.");
        return result;
    }

    public async Task<List<CustomerDto>> GetCustomers(string? name = null)
    {
        IQueryable<Customer> customersResults;
        if (!String.IsNullOrWhiteSpace(name))
        {
            name = name.Trim();
            string cleanName = Regex.Replace(name, @"\s+", " "); //compressing multiple whitespaces to one

            customersResults = _context.Customers

            .Where(c => c.CompanyName.Contains(cleanName) ||
            (c.ContactName != null && c.ContactName.Contains(cleanName)))

            .OrderBy(c =>
            c.CompanyName.StartsWith(cleanName) ||
            (c.ContactName != null && c.ContactName.StartsWith(cleanName)))

            .ThenBy(c => c.CompanyName);
        }
        else
        {
            customersResults = _context.Customers;
        }

        return await customersResults.Select(c => new CustomerDto
        {
            CompanyName = c.CompanyName,
            Name = c.ContactName,
            OrderCount = c.Orders.Count,
            Id = c.CustomerId
        }).ToListAsync();
    }
}