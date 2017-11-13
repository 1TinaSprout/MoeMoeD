using MoeMoeD.BLL;
using MoeMoeD.DAL;
using MoeMoeD.IBLL;
using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;

using Unity;

namespace MoeMoeD
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(
            () =>{
                      var container = new UnityContainer();
                      RegisterTypes(container);
                      return container;
                 }
            );

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUserBLL, UserBLL>();
            container.RegisterType<IFileBLL, FileBLL>();
            container.RegisterType<IFileContentBLL, FileContentBLL>();
            container.RegisterType<IFolderBLL, FolderBLL>();

            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<IFileDAL, FlieDAL>();
            container.RegisterType<IFileContentDAL, FileContentDAL>();
            container.RegisterType<IFolderDAL, FolderDAL>();
            
            container.RegisterType<MoeMoeDEntities>();

            container.RegisterType<User>();
            container.RegisterType<Flie>();
            container.RegisterType<Folder>();
            container.RegisterType<FileContent>();

            container.RegisterType<Model.ViewData.User>();
            container.RegisterType<Model.ViewData.File>();
            container.RegisterType<Model.ViewData.Folder>();
            container.RegisterType<Model.ViewData.FileContent>();

            container.RegisterType<User>();
            container.RegisterType<Flie>();
            container.RegisterType<Folder>();
            container.RegisterType<FileContent>();
        }
    }
}