using System;
using BTG.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTG.Models.ExercisePlanModels
{
    public class PlanDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Client Client { get; set; }
        public string ClientName { get; set; }

        public Exercise Exercise { get; set; }
        public string ExerciseName { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ExerciseList { get; set; }
    }
}

