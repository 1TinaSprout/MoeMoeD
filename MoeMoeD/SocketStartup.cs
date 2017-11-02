using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MoeMoeD.SocketStartup))]

namespace MoeMoeD
{
    public class SocketStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR<ChatConnection>("/connection");
        }
    }
}
