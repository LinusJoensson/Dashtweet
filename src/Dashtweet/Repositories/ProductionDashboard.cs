using Dashtweet.Models;
using Dashtweet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashtweet.Repositories
{
    public class ProductionDashboard : ISocialDashboard
    {
        public List<RegisteredUser> users = new List<RegisteredUser>();
        public List<Profile> profiles = new List<Profile>();

        public void CreateLocalUser(RegisteredUser user)
        {
            users.Add(new RegisteredUser(twitterId: user.TwitterId,
                twitterName: user.TwitterName,
                twitterScreenName: user.TwitterName));
        }

        public RegisteredUser[] GetAllLocalUsers()
        {
            return users.ToArray();
        }

        public RegisteredUser GetLocalUserFromId(int id)
        {
            return users.SingleOrDefault(o => o.Id == id);
        }

        public void SetTwitterAuth(string authSecret, string authKey, int userId)
        {
            throw new NotImplementedException();
        }

        public void SetLocalName(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public int CreateProfile(string name, string[] tracks)
        {
            profiles.Add(new Profile(tracks: tracks)
            {
                Id = profiles.Count,
                ProfileName = name
            });

            return profiles.Last().Id;
        }
    }
}
