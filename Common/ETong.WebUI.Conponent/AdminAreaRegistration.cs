using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace ETong.WebUI.Conponent
{
    public class AdminAreaRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Conponent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            //Resource
            context.MapRoute(
                "ResourceRoute",
                base.AreaRoutePrefix + "/resource/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index" },
                new[] { "MvcContrib.PortableAreas" }
            );
            //Scripts
            context.MapRoute(
                AreaName + "_Scripts",
                base.AreaRoutePrefix + "/Scripts/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index", resourcePath = "Scripts" },
                new[] { "MvcContrib.PortableAreas" }
            );
            //Content
            context.MapRoute(
                AreaName + "_Content",
                base.AreaRoutePrefix + "/Content/{resourceName}",
                new { controller = "EmbeddedResource", action = "Index", resourcePath = "Content" },
                new[] { "MvcContrib.PortableAreas" }
            );            
            //Default
            context.MapRoute(
                AreaName + "_Default",
                AreaName + "/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "ETong.WebUI.Conponent.Controllers" }
            );
            RegisterAreaEmbeddedResources();
        }
    }
}
