using System;
using BTG.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTG.Models.ExerciseModels
{
    public class ExerciseCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string SetsAndReps { get; set; }

        public int CategoryID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryListing { get; set; }

    }
}

