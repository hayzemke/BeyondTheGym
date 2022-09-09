using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTG.Models.CategoryModels;
using BTG.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeyondTheGym_WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            if (categories == null) return View();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _categoryService.CreateCategoryAsync(model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();

        }
    }
}

