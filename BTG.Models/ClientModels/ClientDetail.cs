using System;
using System.ComponentModel.DataAnnotations;
using BTG.Data;

namespace BTG.Models.ClientModels
{
    public class ClientDetail
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Injuries { get; set; }
    }
}

