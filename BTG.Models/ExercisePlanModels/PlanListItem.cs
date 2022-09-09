using System;
using BTG.Data;
using System.ComponentModel.DataAnnotations;

namespace BTG.Models.ExercisePlanModels
{
    public class PlanListItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Exercise Exercise { get; set; }
        public int ExerciseID { get; set; }


        public Client Client { get; set; }
        public string ClientName { get; set; }
        

       
    }
}

