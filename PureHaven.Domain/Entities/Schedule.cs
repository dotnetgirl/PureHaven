using PureHaven.Domain.Commons;
namespace PureHaven.Domain.Entities;
public class Schedule : Auditable
{
    public List<CleaningService> Service { get; set; }
}