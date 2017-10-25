using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MoeMoeD.Controllers;
using MoeMoeD.BLL;
using MoeMoeD.IDAL;
using MoeMoeD.DAL;

namespace MoeMoeD
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterTypes(new UserBLL().GetType().Assembly.ExportedTypes);

            container.RegisterType<IUserDAL,UserDAL>();
            container.RegisterType<IFileDAL, FileDAL>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}