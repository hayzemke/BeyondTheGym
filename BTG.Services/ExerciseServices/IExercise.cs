using System;
using BTG.Models.ClientModels;
using BTG.Models.ExerciseModels;
using BTG.Models.ExercisePlanModels;

namespace BTG.Services.ExerciseServices
{
    public interface IExerciseService
    {
        Task<bool> CreateExerciseAsync(ExerciseCreate model);

        Task <IEnumerable<ExerciseListItem>> SeeAllExercisesAsync();

        Task<bool> UpdateExerciseAsync(int id, ExerciseEdit model);

        Task<ExerciseDetail> GetExerciseDetailsAsync(int? id);


        //Task<bool> AddExerciseToPlanAsync(ExerciseListItem exercise, PlanListItem exercisePlan);

        // Remove from plan?
        //Task<bool> RemoveExerciseFromPlanAsync(ExerciseListItem exercise, PlanListItem exercisePlan);
    }
}

