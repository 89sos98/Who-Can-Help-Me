namespace WhoCanHelpMe.Web.Controllers.Initialisers
{
    #region Using Directives

    using System;
    using System.ComponentModel.Composition;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.Windsor;
    using Framework.Enumerable;
    using Home;
    using N2.Engine.Castle;
    using N2.Web.Mvc;
    using WhoCanHelpMe.Domain.Contracts.Container;

    // use for route debugging
    using MvcContrib.Routing;
    using Extensions;

    #endregion

    /// <summary>
    /// Responsible for all the MVC route registration
    /// </summary>
    [Export(typeof(IComponentRegistrar))]
    public class RouteRegistrar : IComponentRegistrar
    {
        private static string[] NonCmsControllers = new[] { "about", "error", "navigation", "profile", "search", "tag", "user" };

        /// <summary>
        /// Registers the routes into the routes collection
        /// </summary>
        public void Register(IWindsorContainer container)
        {
            AreaRegistration.RegisterAllAreas();

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute(" { *favicon }", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteTable.Routes.RouteExistingFiles = false;

            // ELMAH handles ELMAH
            RouteTable.Routes.IgnoreRoute("elmah.axd");

            // Add routes for non-CMS controllers
            NonCmsControllers.Each(x => RouteTable.Routes.MapRoute(x, x + "/{action}", new { controller = x, action = "Index" }));

            // Initialise N2 for MVC
            container.Kernel.RemoveComponent("CachingService"); // TODO – fix this
            var engine = MvcEngine.Create(new WindsorServiceContainer(container));
            engine.RegisterControllers(typeof(HomeController).Assembly);
            RouteTable.Routes.MapContentRoute("Content", engine);

            // Add Default Route
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            // Uncomment to enable the route debugger, then browse to the URL you want to test as normal.
            // RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }
    }
}