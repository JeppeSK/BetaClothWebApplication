using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothWebApplication.Controllers
{
    [Route("[controller]/[action]/{brandname}")]
    [Route("[controller]/[action]")]
    public class StoreController : Controller
    {

        private readonly InventoryContext _inventoryContext;

        public StoreController(InventoryContext inventoryContext) 
        {
            this._inventoryContext = inventoryContext;
        }

        // GET: StoreController1
        public ActionResult allProducts()
        {
            InventoryContext inventoryContext = new InventoryContext();

            ViewBag.Clothes = inventoryContext.Clothes;

            return View();
        }

        // GET: StoreController/Details/5
        public ActionResult brand(string brandname)
        {
            InventoryContext inventoryContext = new InventoryContext();

            if (brandname.Equals("Nike"))
            {
                var brands = inventoryContext.Clothes.Where(x => x.BrandBrandId == 2).ToList();
                ViewBag.Clothes = brands;
            }
            else if (brandname.Equals("Tommy_Hilfinger"))
            {
                var brands = inventoryContext.Clothes.Where(x => x.BrandBrandId == 3).ToList();
                ViewBag.Clothes = brands;
            } 
            else if (brandname.Equals("Tiger_Of_Sweden"))
            {
                var brands = inventoryContext.Clothes.Where(x => x.BrandBrandId == 1).ToList();
                ViewBag.Clothes = brands;
            }
            else if (brandname.Equals("Les_Deux"))
            {
                var brands = inventoryContext.Clothes.Where(x => x.BrandBrandId == 4).ToList();
                ViewBag.Clothes = brands;
            }

            return View();
        }
    }
}
