using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi.Models;
using Tweetinvi;
using Tweetinvi.Credentials.Models;
using System.Diagnostics;
using Dashtweet.Repositories;
using Microsoft.AspNetCore.Http;
using Dashtweet.ApplicationUtilities;

namespace Dashtweet.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        private static IAuthenticationContext _authenticationContext;

        ISocialDashboard _socialDashboard;

        public AuthenticationController(ISocialDashboard socialDashboard)
        {
            _socialDashboard = socialDashboard;
        }

        public ActionResult TwitterAuth()
        {
            var appCreds = new ConsumerCredentials(ApplicationUtilities.ApplicationConstants._consumerKey,
                ApplicationUtilities.ApplicationConstants._consumerSecret);

            var redirectURL = "http://" + Request.Host.Host + ":" + Request.Host.Port +
                "/Authentication/ValidateTwitterAuth";

            _authenticationContext = AuthFlow.InitAuthentication(appCreds, redirectURL);

            return new RedirectResult(_authenticationContext.AuthorizationURL);
        }

        public ActionResult ValidateTwitterAuth()
        {
            var aouthUser = Tweetinvi.User.GetAuthenticatedUser(
                AuthFlow.CreateCredentialsFromVerifierCode(
                    Request.Query["oauth_verifier"],
                    _authenticationContext));

            var thisUser = _socialDashboard.GetAllLocalUsers()
                .SingleOrDefault(o => o.TwitterId == aouthUser.Id);

            if (thisUser == null)
            {
                _socialDashboard.CreateLocalUser(new Models.RegisteredUser(
                    twitterId: aouthUser.Id,
                    twitterName: aouthUser.Name,
                    twitterScreenName: aouthUser.ScreenName));
            }

            HttpContext.Session.SetString(SessionStrings._twitterId, aouthUser.IdStr);

            return RedirectToAction("Index", "Home");
        }
    }
}
