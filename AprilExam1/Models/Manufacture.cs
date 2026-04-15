using System;
using System.Collections.Generic;

namespace AprilExam1.Models;

public partial class Manufacture
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
