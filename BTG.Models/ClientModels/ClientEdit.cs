using System;
using System.ComponentModel.DataAnnotations;

namespace BTG.Models.ClientModels
{
    public class ClientEdit
    {
        //public string ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Injuries { get; set; }
    }
}

