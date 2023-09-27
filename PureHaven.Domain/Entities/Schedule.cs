using PureHaven.Domain.Commons;

namespace PureHaven.Domain.Entities;

public class Schedule : Auditable
{
    public long EmployeeId { get; set; }
    public long OrderId { get; set; }
    public List<HomeCleaningInfo> HomeCleaningInfo { get; set; }
}