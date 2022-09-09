using System;
using System.ComponentModel.DataAnnotations;

namespace BTG.Models.ExerciseModels
{
    public class ExerciseDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string SetsAndReps { get; set; }

        public string CategoryName { get; set; }
    }
}

