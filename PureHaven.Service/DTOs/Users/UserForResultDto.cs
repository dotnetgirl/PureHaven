﻿using PureHaven.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PureHaven.Service.DTOs.Users;
public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
