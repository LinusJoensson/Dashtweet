using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashtweet.Repositories;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Dashtweet.Models;
using Microsoft.AspNetCore.Hosting;
using Dashtweet.ViewModels;
using Dashtweet.ApplicationUtilities;

namespace Dashtweet.Controllers
{
    public class HomeController : Controller
    {
        ISocialDashboard _socialDashboard;

        public HomeController(ISocialDashboard socialDashboard)
        {
            _socialDashboard = socialDashboard;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionStrings._twitterId)))
            {
                long thisTwitterId = 0;

                if (long.TryParse(HttpContext.Session.GetString(SessionStrings._twitterId), out thisTwitterId) == false)
                    return RedirectToAction("TwitterAuth", "Authentication");

                if (thisTwitterId == 0)
                    return RedirectToAction("TwitterAuth", "Authentication");

                var thisUser = _socialDashboard.GetAllLocalUsers()
                    .SingleOrDefault(o => o.TwitterId == thisTwitterId);

                return View(new RegisteredUser
                    (twitterId: thisUser.TwitterId,
                    twitterName: thisUser.TwitterName,
                    twitterScreenName: thisUser.TwitterScreenName));
            }
            else
            {
                return RedirectToAction("TwitterAuth", "Authentication");
            }
        }

        public IActionResult Dashboard()
        {
            DashboardVM viewModel = null;
            RegisteredUser thisUser = null;
            long sessionTwitterId = 0;

            if (long.TryParse(HttpContext.Session.GetString("twitterId"), out sessionTwitterId) == false)
                return View(null);

            if (sessionTwitterId > 0)
                thisUser = _socialDashboard.GetAllLocalUsers().SingleOrDefault(o => o.TwitterId == sessionTwitterId);

            if (thisUser != null)
            {
                viewModel = new DashboardVM(twitterId: thisUser.TwitterId,
                    twitterName: thisUser.TwitterName,
                    twitterScreenName: thisUser.TwitterScreenName);
            }

            return View(viewModel);
        }
    }
}
