using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTG.Data;

namespace BTG.Models.ExerciseModels
{
    public class ExerciseListItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string SetsAndReps { get; set; }

        public string CategoryName { get; set; } 

        //public List<ExercisePlan> ExercisePlans { get; set; } = new List<ExercisePlan>();
    }

}

