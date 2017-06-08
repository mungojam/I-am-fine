using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace IAmFine.WebFull
{
    public class ChatHub : Hub
    {
        public void help()
        {
            Clients.All.help();
        }

        public void messageFromManager(string message)
        {
            Clients.All.messageFromManager(message);
        }
    }
}