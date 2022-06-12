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
            var client = new SendGridClient("");//todo setup a way so the api key is not visable
            return client;
        }


        public Email BuildEmail(User user)
        {
            var email = new Email
            {
                SendTo = new EmailAddress(user.Email, user.UserName),
                SendFrom = new EmailAddress("herier44@gmail.com", "sender"),
                Body = "This is a test body.",
                Subject = "This is a test email."
            };

            return email;
        }

        public async Task<IActionResult> sendEmailAsync(User user, SendGridClient smtp, Email email)
        {
            var message = MailHelper.CreateSingleEmail(email.SendFrom, email.SendTo, email.Subject, email.Body, "");

            var response = await smtp.SendEmailAsync(message);

            return View("~/Views/Home/EmailSent.cshtml", user);
        }

    }
}
