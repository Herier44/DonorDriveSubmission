using Culture_Shock.Models;
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
        public async Task<IActionResult> AddUsersName(User user)
        {

            return View("~/Views/Home/EmailSent.cshtml", user);
        }

        public SmtpClient GetSmtpClient()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("herier44@gmail.com", "password")
            };

            return smtp;
        }
    }
}
