using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BTG.Data
{
    public class Client : IdentityUser 
    {
        //[Key]
        //public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Injuries { get; set; }

        //[Required]
        //[ForeignKey(nameof(ExercisePlan))]
        //public ExercisePlan Exercises { get; set; }
        //public int ExercisePlanID { get; set; }

        public List<ExercisePlan> ExercisePlans { get; set; } = new List<ExercisePlan>();

        public string ClientName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

    }
}

