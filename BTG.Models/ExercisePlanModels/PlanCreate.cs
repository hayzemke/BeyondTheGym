using System;
using BTG.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTG.Models.ExercisePlanModels
{
    public class PlanCreate
    {
        public string Name { get; set; }

        public int ExerciseID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ExerciseList { get; set; }

        public string ClientID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ClientList { get; set; }

    }
}

