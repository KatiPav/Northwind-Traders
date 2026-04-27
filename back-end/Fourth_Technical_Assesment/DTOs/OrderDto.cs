
namespace Fourth_Technical_Assesment;

public class OrderDto
{
    public int OrderId { get; set; }
    public decimal TotalValue { get; set; }
    public int ProductCount { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipCountry { get; set; }


}