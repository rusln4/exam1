using System;
using System.Collections.Generic;

namespace AprilExam1.Models;

public partial class Image
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
