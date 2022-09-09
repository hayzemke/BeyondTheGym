using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTG.Models.ExerciseModels;
using BTG.Models.ExercisePlanModels;
using BTG.Services.CategoryServices;
using BTG.Services.ClientServices;
using BTG.Services.ExercisePlanServices;
using BTG.Services.ExerciseServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeyondTheGym_WebApp.Controllers
{
    public class ExercisePlanController : Controller
    {
        private readonly IExercisePlan _planService;
        private readonly IClientService _clientService;
        private readonly IExerciseService _exerciseService;


        public ExercisePlanController(IExercisePlan planService, IClientService clientService, IExerciseService exerciseService)
        {
            _planService = planService;
            _clientService = clientService;
            _exerciseService = exerciseService;
        }

        //GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var plans = await _planService.GetAllExercisePlansAsync();

            if (plans == null)
            {
                return View();
            }

            return View(plans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var planCreate = new PlanCreate();

            planCreate.ClientList = _clientService.GetClients().Result.Select(x => new SelectListItem
            {
                Text = x.LastName,
                Value = x.ID.ToString(),
            });

            planCreate.ExerciseList = _exerciseService.SeeAllExercisesAsync().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString(),
            });

            return View(planCreate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanCreate model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _planService.CreateExercisePlanAsync(model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            var planEdit = new PlanEdit();

            planEdit.ClientList = _clientService.GetClients().Result.Select(x => new SelectListItem
            {
                Text = x.LastName,
                Value = x.ID.ToString(),
            });

            planEdit.ExerciseList = _exerciseService.SeeAllExercisesAsync().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString(),
            });


            return View(planEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlanEdit model)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _planService.UpdateExercisePlanAsync(id, model)) return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var plan = await _planService.GetPlanDetailsAsync(id.Value);

            return View(plan);
        }

    }
}

