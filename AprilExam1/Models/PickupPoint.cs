using System;
using System.Collections.Generic;

namespace AprilExam1.Models;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string NumberHouse { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
