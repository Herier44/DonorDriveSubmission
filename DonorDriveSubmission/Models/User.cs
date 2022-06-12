using System;
using System.ComponentModel.DataAnnotations;

namespace Culture_Shock.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string LastName { get; set; }

    }
}
