using Culture_Shock.Models;
using DonorDriveSubmission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace DonorDriveSubmission.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> AddUsersNameAsync(User user)
        {

            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.FirstName) || 
                string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
            {
                return View("~/Views/Home/Index.cshtml");
            }
            
            var smtp = GetSendGridClient();
            var email = BuildEmail(user);
            await sendEmailAsync(user, smtp, email);

            return View("~/Views/Home/EmailSent.cshtml", user);
        }

        public SendGridClient GetSendGridClient()
        {
            var apiKey = "";//Environment.GetEnvironmentVariable("TestEmailAPI");
            //I know this can be set up with environment variables as the commented code shows above but for this project pasting it in seemed easier.
            var client = new SendGridClient(apiKey);
            return client;
        }


        public Email BuildEmail(User user)
        {
            var email = new Email
            {
                SendTo = new EmailAddress(user.Email, user.UserName),
                SendFrom = new EmailAddress("herier44@gmail.com", "David Herier"),
                Body = $"The information used to sign up for {user.FirstName} {user.LastName}'s account was: " +
                $"Email: {user.Email}" +
                $" User name: {user.UserName}",
                Subject = $"Thanks for singing up {user.FirstName}.",
                HTML = $"The information used to sign up for {user.FirstName} {user.LastName}'s account was: <br />" +
                $"Email: {user.Email} <br />" +
                $"User name: {user.UserName}"
            };

            return email;
        }

        public async Task sendEmailAsync(User user, SendGridClient smtp, Email email)
        {
            var message = MailHelper.CreateSingleEmail(email.SendFrom, email.SendTo, email.Subject, email.Body, email.HTML);

            var response = await smtp.SendEmailAsync(message);

        }

    }
}
