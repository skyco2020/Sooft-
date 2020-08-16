using BusinessServices.Interfaces;
using BusinessServices.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc4;

namespace SooftApi
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

            container.RegisterType<ISingerService, SingerService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IGenderService, GenderService>();
            container.RegisterType<ISongService, SongService>();

            return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}