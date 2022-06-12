using SendGrid.Helpers.Mail;

namespace DonorDriveSubmission.Models
{
    public class Email
    {
        public EmailAddress SendFrom { get; set; }
        public EmailAddress SendTo { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

    }
}
