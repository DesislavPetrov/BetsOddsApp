using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication10.Hubs
{
    public class MatchesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["BettingOddsContext"].ToString();

        [HubMethodName("sendMatches")]
        public static void SendMatches()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MatchesHub>();
            context.Clients.All.updateMatches();
        }
    }
}