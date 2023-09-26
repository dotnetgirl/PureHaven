﻿namespace PureHaven.Service.DTOs.CleaningServices;
public class CleaningServiceForResultDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; } = 2;
}
