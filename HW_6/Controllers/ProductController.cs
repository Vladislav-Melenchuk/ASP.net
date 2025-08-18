using HW_6.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_6.Controllers
{
    public class ProductController : Controller
    {

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Title = "C# Book", Author = "John", Price = 30, Category = "Books", Description = "Learn C#" },
            new Product { Id = 2, Title = "Java Book", Author = "Jane", Price = 25, Category = "Books", Description = "Learn Java" }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
         
                product.Id = products.Any() ? products.Max(p => p.Id) + 1: 1;
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Details(int id)
        {
            
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Search(string keyword)
        {
            List<Product> filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Title.ToLower().Contains(keyword.ToLower()))
                {
                    filteredProducts.Add(product);
                }
            }

            return View("Index", filteredProducts);
        }
    }
}
