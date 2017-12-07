using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;
using MoeMoeD.Model.ViewData;
using MoeMoeD.Controllers;
using MoeMoeD.IBLL;

namespace MoeMoeD
{
    public class ChatConnection : PersistentConnection
    {
        public IUserBLL UserBLL { get; set; }
        
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(request.QueryString.ToString(), "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Data value = JsonConvert.DeserializeObject<Data>(data);

            if (value.Command.Equals("0"))
            {
                var set = ChatroomController.UserSet;
                if (!set.Keys.Contains(value.Name))
                {
                    User user = UserBLL.GetByName(value.Name);
                    foreach (var i in set)
                    {
                        Connection.Send(connectionId, new { Command =  1, User = i.Value });
                    }
                    set.Add(value.Name, user);
                    AddUser(user);
                }
                return Connection.Broadcast(data);
            }
            else if (value.Command.Equals("1"))
            {
                User user = UserBLL.GetByName(value.Name);
                AddUser(user);
            }
            else if (value.Command.Equals("2"))
            {
                User user = UserBLL.GetByName(value.Name);
                RemoveUser(user);
            }
            return Connection.Broadcast(String.Empty);
        }

        private class Data
        {
            public String Command { get; set; }
            public String Name { get; set; }
            public String Content { get; set; }
        }

        public void AddUser(User user)
        {
            if (!ChatroomController.UserSet.Keys.Contains(user.Name))
            {
                ChatroomController.UserSet.Add(user.Name, user);
            }
            var value = JsonConvert.SerializeObject(user);
            Connection.Broadcast(JsonConvert.SerializeObject(new { Command = 1, User = value }));
        }

        public void RemoveUser(User user)
        {
            if (ChatroomController.UserSet.Keys.Contains(user.Name))
            {
                ChatroomController.UserSet.Remove(user.Name);
            }
            var value = JsonConvert.SerializeObject(user);
            Connection.Broadcast(JsonConvert.SerializeObject(new { Command = 2, User = value }));
        }
    }
}