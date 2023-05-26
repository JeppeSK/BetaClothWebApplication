using System;
using System.Collections.Generic;

namespace ClothWebApplication.Models;

public partial class Cloth
{
    public int Id { get; set; }

    public string? Color { get; set; }

    public string? Fabric { get; set; }

    public double Price { get; set; }

    public int Inventory { get; set; }

    public bool? HasHood { get; set; }

    public int? WaistSize { get; set; }

    public string Discriminator { get; set; } = null!;

    public int? BrandBrandId { get; set; }

    public string? JacketSize { get; set; }

    public string? PantsSize { get; set; }

    public string? TshirtSize { get; set; }

    public string? Image { get; set; }

    public virtual Brand? BrandBrand { get; set; }
}
