using Microsoft.AspNetCore.Mvc;
using Practice2.Interfaces;
using Practice2.Models;
using Practice2.ViewModels;
using System.Diagnostics;

namespace Practice2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategory _categories;
        private readonly IPublication _publications;
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(ICategory categories, IPublication publications, IWebHostEnvironment appEnvironment)
        {
            _categories = categories;
            _publications = publications;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index(QueryOptions? options, string? categoryId)
        {
            var allCategories = await _categories.GetAllCategoriesAsync();
            var allPublications = await _publications.GetAllPublicationsByCategoryWithCategories(options, categoryId);

            return View(new IndexViewModel
            {
                Categories = allCategories.ToList(),
                Publications = allPublications
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }

}
