using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            String name = request.QueryString["UserName"];
            ChatroomController.UserSet.Add(name, UserBLL.GetByName(name));

            return Connection.Send(request.QueryString.ToString(), "Welcome!");
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }
    }
}