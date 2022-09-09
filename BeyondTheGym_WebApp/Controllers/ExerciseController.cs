using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTG.Models.ClientModels;
using BTG.Models.ExerciseModels;
using BTG.Services.CategoryServices;
using BTG.Services.ClientServices;
using BTG.Services.ExerciseServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeyondTheGym_WebApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        private readonly ICategoryService _categoryService;

        public ExerciseController(IExerciseService exerciseService, ICategoryService categoryService)
        {
            _exerciseService = exerciseService;
            _categoryService = categoryService;
        }

        //GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var exercises = await _exerciseService.SeeAllExercisesAsync();

            if (exercises == null)
            {
                return View();
            }

            return View(exercises);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var exerciseCreate = new ExerciseCreate();

            exerciseCreate.CategoryListing = _categoryService.GetAllCategoriesAsync().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

           
            return View(exerciseCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExerciseCreate model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _exerciseService.CreateExerciseAsync(model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            var exerciseEdit = new ExerciseEdit();

            exerciseEdit.CategoryListing = _categoryService.GetAllCategoriesAsync().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });


            return View(exerciseEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExerciseEdit model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _exerciseService.UpdateExerciseAsync(id, model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var exercise = await _exerciseService.GetExerciseDetailsAsync(id.Value);

            return View(exercise);
        }

       
    }
}

