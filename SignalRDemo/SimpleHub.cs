using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRDemo
{
    public class SimpleMessage
    {
        public string Name { get; set; }
        
        public string Message { get; set; }
    }

    public class SimpleHub : Hub
    {
        private static int _count = 0;
        public void Connected()
        {
            //Context.User.Identity.IsAuthenticated
            //Context.User.Identity.Name
            _count++;
            Clients.All.newConnection($"User {_count} connected");
        }

        public void NewMessage(string name, string message)
        {
            Clients.All.newMessagePosted(new SimpleMessage
            {
                Name = name, Message = message
            });
        }
    }
}