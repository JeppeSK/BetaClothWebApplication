using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothWebApplication.ViewModels
{
    public class CreationViewModel
    {
        public double Price { get; set; }
        public int Inventory { get; set; }
        public bool? HasHood { get; set; }
        public int? WaistSize { get; set; }
        public string? Image { get; set; }


        public List<SelectListItem> SelectModel { get; set; }
        public string SelectedModel { get; set; }
        public List<SelectListItem> BrandsSelectList { get; set; }
        public string SelectedBrand { get; set; }
        public List<SelectListItem> SelectSize { get; set; }
        public string SelectedSize { get; set; }
        public List<SelectListItem> SelectColor { get; set; }
        public string SelectedColor { get; set; }
        public List<SelectListItem> SelectFabric { get; set; }
        public string SelectedFabric { get; set; }

        public CreationViewModel()
        {
            SelectModel = new List<SelectListItem>()
            {
            new SelectListItem { Text="Pants", Value="Pants" },
            new SelectListItem { Text="Tshirt", Value="Tshirt"},
            new SelectListItem { Text="Jacket", Value="Jacket"},
            new SelectListItem { Text="Shoes", Value="Shoes"},
            };

            SelectSize = new List<SelectListItem>()
            {
            new SelectListItem { Text="Xtra Small", Value="Xtra Small" },
            new SelectListItem { Text="Small", Value="Small"},
            new SelectListItem { Text="Medium", Value="Medium"},
            new SelectListItem { Text="Large", Value="Large"},
            new SelectListItem { Text="Xtra Large", Value="Xtra Large"},
            };

            SelectColor = new List<SelectListItem>()
            {
            new SelectListItem { Text="Red", Value="Red" },
            new SelectListItem { Text="Grey", Value="Grey" },
            new SelectListItem { Text="Yellow", Value="Yellow" },
            new SelectListItem { Text="Blue", Value="Blue" },
            new SelectListItem { Text="Black", Value="Black" },
            new SelectListItem { Text="Green", Value="Green" },
            new SelectListItem { Text="Navy Blue", Value="Navy Blue" },
            new SelectListItem { Text="White", Value="White" },
            new SelectListItem { Text="Beige", Value="Beige" },
            new SelectListItem { Text="Brown", Value="Brown" },
            };

            SelectFabric = new List<SelectListItem>()
            {
            new SelectListItem { Text="Denim", Value="Denim" },
            new SelectListItem { Text="100% Cotton", Value="100% Cotton"},
            new SelectListItem { Text="Linen", Value="Linen"},
            new SelectListItem { Text="Leather", Value="Leather"},
            new SelectListItem { Text="Satin", Value="Satin"},
            new SelectListItem { Text="Woven", Value="Woven"},
            new SelectListItem { Text="Silk", Value="Silk"},
            new SelectListItem { Text="Wool", Value="Wool"},
            };

        }
    }
}
