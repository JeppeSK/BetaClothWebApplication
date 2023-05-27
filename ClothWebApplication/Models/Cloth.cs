using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClothWebApplication.Models;

public partial class Cloth
{
    [Key] public int Id { get; set; }

    public string? Color { get; set; }

    public string? Fabric { get; set; }

    public double Price { get; set; }

    public int Inventory { get; set; }

    public bool? HasHood { get; set; }

    public int? WaistSize { get; set; }

    public string Discriminator { get; set; } = null!;

    public int? BrandBrandId { get; set; }

    public string? Size { get; set; }

    public string? Image { get; set; }

    public virtual Brand? BrandBrand { get; set; }
}
