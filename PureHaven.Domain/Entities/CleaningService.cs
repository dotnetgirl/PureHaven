using PureHaven.Domain.Commons;
namespace PureHaven.Domain.Entities;

public class CleaningService : Auditable
{
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
}