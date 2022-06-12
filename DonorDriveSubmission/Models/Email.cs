using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorDriveSubmission.Models
{
    public class Email
    {
        public string SendFrom { get; set; }
        public string SendTo { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

    }
}
