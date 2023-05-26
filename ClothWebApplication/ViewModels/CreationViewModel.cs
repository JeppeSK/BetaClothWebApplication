using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothWebApplication.ViewModels
{
    public class CreationViewModel
    {
        [BindProperty]
        public Cloth Clothmodel { get; set; }
        public List<SelectListItem> Model { get; set; }
        public string Brandtype { get; set; }

        public List<SelectListItem> BrandsSelectList { get; set; }

        public List<SelectListItem> Size { get; set; }

        public List<SelectListItem> Color { get; set; }

        public List<SelectListItem> Fabric { get; set; }

        public CreationViewModel()
        {
            Model = new List<SelectListItem>()
            {
            new SelectListItem { Text="Pants", Value="1" },
            new SelectListItem { Text="Tshirt", Value="2"},
            new SelectListItem { Text="Jacket", Value="3"},
            new SelectListItem { Text="Shoes", Value="4"},
            };

            Size = new List<SelectListItem>()
            {
            new SelectListItem { Text="Xtra Small", Value="1" },
            new SelectListItem { Text="Small", Value="2"},
            new SelectListItem { Text="Medium", Value="3"},
            new SelectListItem { Text="Large", Value="4"},
            new SelectListItem { Text="Xtra Large", Value="5"},
            };

            Color = new List<SelectListItem>()
            {
            new SelectListItem { Text="Red", Value="1" },
            new SelectListItem { Text="Grey", Value="2" },
            new SelectListItem { Text="Yellow", Value="3" },
            new SelectListItem { Text="Blue", Value="4" },
            new SelectListItem { Text="Black", Value="5" },
            new SelectListItem { Text="Green", Value="6" },
            new SelectListItem { Text="Navy Blue", Value="7" },
            new SelectListItem { Text="White", Value="8" },
            new SelectListItem { Text="Beige", Value="9" },
            new SelectListItem { Text="Brown", Value="10" },
            };

            Fabric = new List<SelectListItem>()
            {
            new SelectListItem { Text="Denim", Value="1" },
            new SelectListItem { Text="100% Cotton", Value="2"},
            new SelectListItem { Text="Linen", Value="3"},
            new SelectListItem { Text="Leather", Value="4"},
            new SelectListItem { Text="Satin", Value="5"},
            new SelectListItem { Text="Woven", Value="6"},
            new SelectListItem { Text="Silk", Value="7"},
            new SelectListItem { Text="Wool", Value="8"},
            };

        }
    }
}
