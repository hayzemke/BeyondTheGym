using System;
using BeyondTheGym_WebApp.Data.Data;
using BTG.Data;
using BTG.Models.ExercisePlanModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BTG.Services.ExercisePlanServices
{
    public class ExercisePlanService : IExercisePlan
    {
        private readonly ApplicationDbContext _context;

        public ExercisePlanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanListItem>> GetAllExercisePlansAsync()
        {
            var plans = await _context.ExercisePlans.Select(p => new PlanListItem
            {
                ID = p.ID,
                Name = p.Name,
                ExerciseID = p.ExerciseID,
               ClientName = p.Client.ClientName,
            }).ToListAsync();

            return plans;
        }

        public async Task<bool> CreateExercisePlanAsync(PlanCreate model)
        {
            if (model is null) return false;

            var exercisePlan = new ExercisePlan
            {
                Name = model.Name,
                ExerciseID = model.ExerciseID,
                ClientID = model.ClientID
            };

            _context.ExercisePlans.Add(exercisePlan);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateExercisePlanAsync(int id, PlanEdit model)
        {
            if (model is null) return false;

            var entity = await _context.ExercisePlans.SingleOrDefaultAsync(x => x.ID == id);
            if (entity is null) return false;

            entity.Name = model.Name;
            entity.ExerciseID = model.ExerciseID;
            entity.ClientID = model.ClientID;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<PlanDetail> GetPlanDetailsAsync(int? id)
        {
            var plan = await _context.ExercisePlans.Include(p => p.Client).Include(e=>e.Exercise).SingleOrDefaultAsync(x => x.ID == id);
          
            if (plan is null) return null;

            return new PlanDetail
            {
                ID = plan.ID,
                Name = plan.Name,
                ClientName = plan.Client.ClientName,
                ExerciseName = plan.Exercise.Name,

            };
        }


        //bookingViewModel.PatientList = db.Patients.Select(p => new SelectListItem()
        //{
        //    Value = p.PatientId.ToString(),
        //    Text = p.User.FirstName + " " + p.User.LastName
        //});


        //public Task<IEnumerable<PlanListItem>> GetExericsePlanByNameAsync(Exercise LastName)
        //{
        //    //* terrys help


        //}

    }
}

