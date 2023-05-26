using ClothWebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public IActionResult CreateModel()
        {

            InventoryContext inventory = new InventoryContext();
            
            CreationViewModel viewModel = new CreationViewModel();

            Brand brand = new Brand();
            Cloth cloth = new Cloth();

            if (viewModel.Clothmodel.Discriminator.Equals("Tshirt"))
            {
                cloth.Discriminator = viewModel.Clothmodel.Discriminator.ToString();
                cloth.Color = viewModel.Clothmodel.ToString();
                cloth.Size = viewModel.Clothmodel.ToString();
                cloth.Fabric = viewModel.Clothmodel.ToString();
                cloth.Inventory = Convert.ToInt32(viewModel.Clothmodel.Inventory.ToString());
                cloth.Price = Convert.ToInt32(viewModel.Clothmodel.Price.ToString());

                brand = (from b in inventory.Brands
                         where b.BrandName.Equals(viewModel.Clothmodel.BrandBrand.BrandName.ToString())
                         select b).FirstOrDefault();

                cloth.BrandBrand = brand;

                inventory.Clothes.Add(cloth);
                inventory.SaveChanges();
            }

            return View("Index");
        }

    }
}
