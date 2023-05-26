using ClothWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothWebApplication.Controllers
{
    public class CreateController : Controller
    {
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
        public IActionResult CreateModel(Cloth cloth)
        {

            InventoryContext inventory = new InventoryContext();

            inventory.Clothes.Add(cloth);
            inventory.SaveChanges();

            return View("Index");
        }

    }
}
