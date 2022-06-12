using Culture_Shock.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorDriveSubmission.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> AddUsersName(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("~/Views/Home/EmailSent.cshtml", user);
        }
    }
}
