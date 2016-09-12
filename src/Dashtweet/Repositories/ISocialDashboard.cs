using Dashtweet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashtweet.Repositories
{
    public interface ISocialDashboard
    {
        void CreateLocalUser(RegisteredUser user);
        RegisteredUser GetLocalUserFromId(int id);
        void SetLocalName(int id, string name);
        RegisteredUser[] GetAllLocalUsers();
        void SetTwitterAuth(string authSecret, string authKey, int localUserId);
        int CreateProfile(string name, string[] tracks);
    }
}
