using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAmFine.Data;
using Microsoft.AspNet.SignalR;
using NotificationService;

namespace IAmFine.WebFull
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
            Service = new AmFineService();
            NotificationClass = new NotificationService.Notification();
        }

        private AmFineService Service { get; }
        private NotificationService.Notification NotificationClass { get; }

        public void urgentHelp()
        {
            Clients.All.urgentHelp();
            NotificationClass.SendNotification("Urgent Help");

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