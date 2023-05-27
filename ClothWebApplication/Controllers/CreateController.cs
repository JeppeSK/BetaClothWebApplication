using ClothWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public async Task<IActionResult> CreateModel(CreationViewModel addCloth)
        {

            Brand? brand = (from b in _inventoryContext.Brands
                           where b.BrandId == Convert.ToInt32(addCloth.SelectedBrand)
                           select b).FirstOrDefault();

            var cloth = new Cloth()
            {
                Discriminator = addCloth.SelectedModel,
                Color = addCloth.SelectedColor,
                Fabric = addCloth.SelectedFabric,
                HasHood = addCloth.HasHood,
                Image = addCloth.Image,
                Size = addCloth.SelectedSize,
                WaistSize = addCloth.WaistSize,
                Inventory = addCloth.Inventory,
                Price = addCloth.Price,
                BrandBrandId = Convert.ToInt32(addCloth.SelectedBrand),
                BrandBrand = brand,
            };

            await _inventoryContext.AddAsync(cloth);
            await _inventoryContext.SaveChangesAsync();

            return RedirectToAction("CreateModel");
        }

    }
}
