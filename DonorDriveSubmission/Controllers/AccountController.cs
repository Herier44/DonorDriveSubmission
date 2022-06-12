using Culture_Shock.Models;
using DonorDriveSubmission.Models;
//using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
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
            var smtp = GetSmtpClient();

            var email = BuildEmail(user);

            sendEmail(user, smtp, email);
        }

        public SmtpClient GetSmtpClient()
        {
            var smtp = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("herier44@gmail.com", "")//remember to not push my password, put your credentials in to test
            };

            return smtp;
        }


        public Email BuildEmail(User user)
        {
            var email = new Email
            {
                SendTo = user.Email,
                SendFrom = "herier44@gmail.com",
                Body = "This is a test body.",
                Subject = "This is a test email."
            };

            return email;
        }

        public IActionResult sendEmail(User user, SmtpClient smtp, Email email)
        {
            smtp.Send(email.SendFrom, email.SendTo, email.Subject, email.Body);

            return View("~/Views/Home/EmailSent.cshtml", user);
        }

    }
}
