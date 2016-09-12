using Dashtweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashtweet.ViewModels
{
    public class DashboardVM
    {
        public readonly long TwitterId;
        public readonly string TwitterName;
        public readonly string TwitterScreenName;
        public List<Profile> Profiles { get; set; } = new List<Profile>();

        public DashboardVM(long twitterId, string twitterName, string twitterScreenName)
        {
            TwitterId = twitterId;
            TwitterName = twitterName;
            TwitterScreenName = twitterScreenName;
        }
    }
}
