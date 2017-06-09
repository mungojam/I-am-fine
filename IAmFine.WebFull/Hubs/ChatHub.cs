using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace IAmFine.WebFull
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
            //Service = new AmFineService();
        }

        //private AmFineService Service { get; }

        public void urgentHelp()
        {
            Clients.All.urgentHelp();
        }

        public void someHelp()
        {
            Clients.All.someHelp();
        }

        public void noHelp()
        {
            Clients.All.noHelp();
        }

        public void messageFromManager(string message)
        {
            Clients.All.messageFromManager(message);
        }
    }
}