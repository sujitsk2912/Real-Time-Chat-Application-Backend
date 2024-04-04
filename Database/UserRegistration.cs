using System;
using System.Collections.Generic;

namespace Real_Time_Chat_Application_Backend.Database;

public partial class UserRegistration
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Nickname { get; set; }
}
