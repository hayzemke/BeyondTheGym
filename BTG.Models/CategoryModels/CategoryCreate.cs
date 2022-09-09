using System;
using System.ComponentModel.DataAnnotations;

namespace BTG.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }
    }
}

