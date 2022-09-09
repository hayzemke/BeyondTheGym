using System;
using BTG.Data;
using BTG.Models.ClientModels;
using BTG.Models.ExercisePlanModels;

namespace BTG.Services.ExercisePlanServices
{
    public interface IExercisePlan
    {
        Task<bool> CreateExercisePlanAsync(PlanCreate model);

        Task<IEnumerable<PlanListItem>> GetAllExercisePlansAsync();

        Task<PlanDetail> GetPlanDetailsAsync(int? id);

        Task<bool> UpdateExercisePlanAsync(int id, PlanEdit model);
    }
}