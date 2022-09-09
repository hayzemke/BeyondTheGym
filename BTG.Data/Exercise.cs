using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTG.Data
{
    public class Exercise
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string SetsAndReps { get; set; }

        public int CategoryID {get; set;}

        [ForeignKey(nameof(CategoryID))]
        public virtual Category Category { get; set; }
    }
}

