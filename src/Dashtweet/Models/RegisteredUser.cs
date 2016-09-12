using Dashtwett.TwitterTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;

namespace Dashtweet.Models
{
    public class RegisteredUser
    {
        public int Id { get; set; }
        public string LocalName { get; set; }
        public string LocalPassword { get; set; }

        public readonly long TwitterId;
        public readonly string TwitterName;
        public readonly string TwitterScreenName;
        public readonly string AouthSecret;
        public readonly string AouthKey;

        public List<Profile> Profiles { get; set; }
        public static TwitterStreamer twitterStreamer = new TwitterStreamer();

        public RegisteredUser(long twitterId, string twitterName, string twitterScreenName)
        {
            TwitterId = twitterId;
            TwitterName = twitterName;
            TwitterScreenName = twitterScreenName;
        }
    }
}
