using System;
using System.ComponentModel.DataAnnotations;

namespace DonorDriveSubmission.Models
{
    public class User
    {
        //Username
        [Required]
        public string UserName { get; set; }
        //email
        [Required]
        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        public string Email { get; set; }
        //First Name
        [Required]
        public string FirstName { get; set; }
        //Last Name
        [Required]
        public string LastName { get; set; }

    }
}
