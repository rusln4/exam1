using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace AprilExam1.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int SupplireId { get; set; }

    public int ManufactureId { get; set; }

    public int CategoryId { get; set; }

    public int Discount { get; set; }

    public string Description { get; set; } = null!;

    [NotMapped]
    public double FinalPrice => Discount > 0 ? Price * (1 - (double)Discount / 100) : Price;

    [NotMapped]
    public bool IsHighDiscount => Discount > 15;

    [NotMapped]
    public bool IsInStock => CountInStorage > 0;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Manufacture Manufacture { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();

    public virtual Supplier Supplire { get; set; } = null!;

   

    [NotMapped]
    public string FullImagePath
    {
        get
        {
            var image = Images.FirstOrDefault();
            if (image == null || string.IsNullOrEmpty(image.Path))
            {
                return "Images/picture.png";
            }
            string fileName = image.Path;
            return $"Images/{fileName}";
            
        }
    }
    [NotMapped]
    public int CountInStorage => Storages.Sum(s => s.Count);

    [NotMapped]
    public string Unit => Storages.FirstOrDefault()?.Unit ?? "шт.";

}
