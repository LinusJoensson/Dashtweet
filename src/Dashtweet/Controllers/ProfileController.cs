using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashtweet.ViewModels;
using Dashtweet.Repositories;

namespace Dashtweet.Controllers
{
    public class ProfileController : Controller
    {
        ISocialDashboard _socialDashboard;

        public IActionResult Create(ISocialDashboard socialDashboard)
        {
            _socialDashboard = socialDashboard;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProfileVM viewModel)
        {
            _socialDashboard.CreateProfile(viewModel.Name, viewModel.Tracks);
            return RedirectToAction("Dashboard", "Home");
        }
    }
}
