using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;
using MoeMoeD.Model.ViewData;
using MoeMoeD.Controllers;
using Unity.Attributes;
using MoeMoeD.IBLL;

namespace MoeMoeD
{
    public class ChatConnection : PersistentConnection
    {
        [Dependency]
        public IUserBLL UserBLL { get; set; }

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(request.QueryString.ToString(), "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Data value = JsonConvert.DeserializeObject<Data>(data);

            if (value.Command.Equals(Command.Message))
            {
                var set = ChatroomController.UserSet;
                if (!set.Keys.Contains(value.Name))
                {
                    User user = UserBLL.GetByName(value.Name);
                    set.Add(value.Name, user);
                    AddUser(user);
                }
                return Connection.Broadcast(new { Command = Command.Message, Data = data });
            }
            else if (value.Command.Equals(Command.AddUser))
            {
                User user = UserBLL.GetByName(value.Name);
                AddUser(user);
            }
            else if (value.Command.Equals(Command.RemoveUser))
            {
                User user = UserBLL.GetByName(value.Name);
                RemoveUser(user);
            }
            return Connection.Broadcast("");
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
            Connection.Broadcast(new { Command = Command.AddUser, User = value });
        }

        public void RemoveUser(User user)
        {
            if (ChatroomController.UserSet.Keys.Contains(user.Name))
            {
                ChatroomController.UserSet.Remove(user.Name);
            }
            var value = JsonConvert.SerializeObject(user);
            Connection.Broadcast(new { Command = Command.RemoveUser, User = value });
        }

        enum Command
        {
            Message,
            AddUser,
            RemoveUser
        }
    }
}