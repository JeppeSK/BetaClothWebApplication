using System;
using System.Collections.Generic;

namespace ClothWebApplication.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? BrandName { get; set; }

    public string? Country { get; set; }

    public string? Logo { get; set; }

    public virtual ICollection<Cloth> Clothes { get; set; } = new List<Cloth>();
}
