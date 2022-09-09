using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTG.Data
{
    public class ExercisePlan
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int ExerciseID { get; set; }

        [ForeignKey(nameof(ExerciseID))]
        public virtual Exercise Exercise { get; set; }

        public string ClientID { get; set; }

        [ForeignKey(nameof(ClientID))]
        public virtual Client Client { get; set; }

    }
}

