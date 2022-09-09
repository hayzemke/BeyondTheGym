using System;
using BeyondTheGym_WebApp.Data.Data;
using BTG.Data;
using BTG.Models.ClientModels;
using BTG.Models.ExerciseModels;
using BTG.Models.ExercisePlanModels;
using Microsoft.EntityFrameworkCore;

namespace BTG.Services.ExerciseServices
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseListItem>> SeeAllExercisesAsync()
        {
            var exercises = await _context.Exercises.Select(e => new ExerciseListItem
            {
                ID=e.ID,
                Name = e.Name,
                CategoryName = e.Category.Name,
                Instructions = e.Instructions,
                SetsAndReps = e.SetsAndReps,
            }).ToListAsync();

            return exercises;
        }

        public async Task<bool> CreateExerciseAsync(ExerciseCreate model)
        {
            if (model is null) return false;

            var exercise = new Exercise
            {
                Name = model.Name,
                Instructions = model.Instructions,
                SetsAndReps = model.SetsAndReps,
                CategoryID = model.CategoryID,
            };

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateExerciseAsync(int id, ExerciseEdit model)
        {
            if (model == null) return false;

            var entity = await _context.Exercises.SingleOrDefaultAsync(x => x.ID == id);
            if (entity is null) return false;

            entity.Name = model.Name;
            entity.Instructions = model.Instructions;
            entity.SetsAndReps = model.SetsAndReps;
            entity.CategoryID = model.CategoryID;

            await _context.SaveChangesAsync();
            return true;

            //SingleOrDefaultAsync(x => x.LastName == lastName);
            //if (entity is null) return false;
        }

        public async Task<ExerciseDetail> GetExerciseDetailsAsync(int? id)
        {
            var exercise = await _context.Exercises.Include(c => c.Category).SingleOrDefaultAsync(x => x.ID == id);
            if (exercise == null) return null;

   
            return new ExerciseDetail
            {
                ID = exercise.ID,
                Name = exercise.Name,
                CategoryName = exercise.Category.Name,
                Instructions = exercise.Instructions,
                SetsAndReps = exercise.SetsAndReps,
            };
        }
    }

        ////2.0?
        //public Task<bool> AddExerciseToPlanAsync(ExerciseListItem exercise, PlanListItem exercisePlan)
        //{
        //    throw new NotImplementedException();
        //}

        ////2.0
        //public Task<bool> RemoveExerciseFromPlanAsync(ExerciseListItem exercise, PlanListItem exercisePlan)
        //{
        //    throw new NotImplementedException();
        //}


    }

