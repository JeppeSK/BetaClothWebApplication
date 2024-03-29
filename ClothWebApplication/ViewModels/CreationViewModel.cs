﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ClothWebApplication.ViewModels
{
    public class CreationViewModel
    {
        [Required]
        [Range(1, 99999.99)]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field is required to specify the amount of the desired Model which is in stock")]
        [Range(1, 1000)]
        public int Inventory { get; set; }
        public bool HasHood { get; set; }
        [Range(24, 41)]
        public int? WaistSize { get; set; }
        public string? Image { get; set; }


        public List<SelectListItem>? SelectModel { get; set; }
        [Required(ErrorMessage = "This field is required to specify which Model you want to create.")]
        public string SelectedModel { get; set; }
        public List<SelectListItem>? BrandsSelectList { get; set; }
        [Required(ErrorMessage = "This field is required to specify the Brand of the Model.")]
        public string? SelectedBrand { get; set; }
        public List<SelectListItem> SelectSize { get; set; }
        [Required(ErrorMessage = "This field is required to give the Model an appropriate Size")]
        public string? SelectedSize { get; set; }
        public List<SelectListItem> SelectColor { get; set; }
        [Required(ErrorMessage = "This field is required to specify the Color of the desired Model")]
        public string? SelectedColor { get; set; }
        public List<SelectListItem> SelectFabric { get; set; }
        [Required(ErrorMessage = "This field is requried to specify the Fabric used for the desired Model")]
        public string? SelectedFabric { get; set; }

        public CreationViewModel()
        {
            SelectModel = new List<SelectListItem>()
            {
            new SelectListItem { Text="Pants", Value="Pants" },
            new SelectListItem { Text="Tshirt", Value="T_shirt"},
            new SelectListItem { Text="Jacket", Value="Jacket"},
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
