using System;
using BTG.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTG.Models.ExerciseModels
{
    public class ExerciseEdit
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string SetsAndReps { get; set; }

        public int CategoryID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryListing { get; set; }

    }
}

