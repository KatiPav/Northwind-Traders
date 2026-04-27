using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fourth_Technical_Assesment;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private ICustomerService _customerService;
    private ILogger<CustomersController> _logger;

    public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers([FromQuery] string? name)
    {

        List<CustomerDto> customers;
        try
        {
            customers = await _customerService.GetCustomers(name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetCustomers could not retrieve customers {name}", name);
            return StatusCode(500, "Something went wrong.");
        }

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer([Required] string id)
    {

        CustomerDetailsDto customerDetails;
        try
        {
            customerDetails = await _customerService.GetCustomerDetailsById(id);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogError(ex, "GetCustomer could not retrive customer with Id: {id}", id);
            return StatusCode(400, "Could not find the customer.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, "Something went wrong.");
        }
        return Ok(customerDetails);
    }
}

