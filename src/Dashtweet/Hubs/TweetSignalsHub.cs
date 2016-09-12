using Microsoft.AspNet.SignalR;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading;
using System.Diagnostics;

namespace Dashtweet.Hubs
{
    public class TweetSignalsHub : Hub
    {
        static int seed = 0;

        IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetSignalsHub>();

        public void Welcome(string message)
        {
            _hubContext.Clients.All.sayHello(message);
            Debug.WriteLine($"Seed: {Interlocked.Increment(ref seed)}");
        }

        internal void SendSlowResponse()
        {
            Thread.Sleep(5000);
            _hubContext.Clients.All.sayHello("Hi, what is your name?");
        }
    }
}
