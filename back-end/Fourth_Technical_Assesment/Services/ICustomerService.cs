using System.ComponentModel;
using System.Collections.Generic;
using Fourth_Technical_Assesment;

namespace Fourth_Technical_Assesment;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetCustomers(string? name = null);
    Task<CustomerDetailsDto> GetCustomerDetailsById(string id);
}