using ClothWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClothWebApplication.Controllers
{
    public class CreateController : Controller
    {

        private readonly InventoryContext _inventoryContext;

        public CreateController(InventoryContext invetory)
        {
            this._inventoryContext = invetory;
        }
        public IActionResult Index()
        {

            InventoryContext inventory = new InventoryContext();
            var BrandData = inventory.Brands.ToList();

            var ViewModel = new CreationViewModel();
            ViewModel.BrandsSelectList = new List<SelectListItem>();

            foreach (var brand in BrandData)
            {
                ViewModel.BrandsSelectList.Add(new SelectListItem { Text = brand.BrandName, Value = brand.BrandId.ToString() });
            }


            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreationViewModel ViewModel)
        {

            InventoryContext inventory = new InventoryContext();
            var BrandData = inventory.Brands.ToList();

            ViewModel.BrandsSelectList = new List<SelectListItem>();

            foreach (var brand in BrandData)
            {
                ViewModel.BrandsSelectList.Add(new SelectListItem { Text = brand.BrandName, Value = brand.BrandId.ToString() });
            }

            //Appropriate Error Validation Messages
            //
            //Price
            if (ViewModel.Price < 1)
            {
                ModelState.AddModelError(nameof(ViewModel.Price), "The price cannot be less than 1");
            }

            if (ViewModel.SelectedModel.ToString().Equals("Pants") && ViewModel.WaistSize < 24 || ViewModel.WaistSize > 41)
            {
                ModelState.AddModelError(nameof(ViewModel.WaistSize), "European waist sizes cannot be less than 25 or above 41");
            }
            
        
            //If Model is valid, create the Model
            ModelState.Remove("BrandsSelectList");
            if (ModelState.IsValid)
            {
                Brand? brand = (from b in _inventoryContext.Brands
                                where b.BrandId == Convert.ToInt32(ViewModel.SelectedBrand)
                                select b).FirstOrDefault();

                
                    var cloth = new Cloth()
                    {
                        Discriminator = ViewModel.SelectedModel,
                        Color = ViewModel.SelectedColor,
                        Fabric = ViewModel.SelectedFabric,
                        HasHood = false,
                        Image = ViewModel.Image,
                        Size = ViewModel.SelectedSize,
                        WaistSize = ViewModel.WaistSize,
                        Inventory = ViewModel.Inventory,
                        Price = ViewModel.Price,
                        BrandBrandId = Convert.ToInt32(ViewModel.SelectedBrand),
                        BrandBrand = brand,
                    };

                    await _inventoryContext.AddAsync(cloth);
                    await _inventoryContext.SaveChangesAsync();

                return Redirect("/Create");
            } 
               
            return View(ViewModel);

        }
    }
}
