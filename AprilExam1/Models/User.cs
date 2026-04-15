using System;
using System.Collections.Generic;

namespace AprilExam1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Sername { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
