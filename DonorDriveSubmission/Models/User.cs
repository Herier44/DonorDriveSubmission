using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Culture_Shock.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email address is invalid.")]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }

    }
}
