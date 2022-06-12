using Culture_Shock.Models;
using DonorDriveSubmission.Models;
//using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DonorDriveSubmission.Controllers
{
    public class AccountController : Controller
    {
        public async Task AddUsersNameAsync(User user)
        {
            var smtp = GetSendGridClient();

            var email = BuildEmail(user);

            await sendEmailAsync(user, smtp, email);
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
                $"User name: {user.UserName}
            };

            return email;
        }

        public async Task<IActionResult> sendEmailAsync(User user, SendGridClient smtp, Email email)
        {
            var message = MailHelper.CreateSingleEmail(email.SendFrom, email.SendTo, email.Subject, email.Body, email.HTML);

            var response = await smtp.SendEmailAsync(message);

            return View("~/Views/Home/EmailSent.cshtml", user);
        }

    }
}
