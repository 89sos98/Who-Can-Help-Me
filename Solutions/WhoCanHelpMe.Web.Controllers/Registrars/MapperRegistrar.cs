namespace WhoCanHelpMe.Web.Controllers.Registrars
{
    #region Using Directives

    using System.ComponentModel.Composition;
    using System.Reflection;
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using Domain.Contracts.Container;

    using Framework.Extensions;

    using MvcContrib.Castle;

    using Properties;

    #endregion

    [Export(typeof(IComponentRegistrar))]
    public class MapperRegistrar : IComponentRegistrar
    {
        public void Register(IWindsorContainer container)
        {
            container.Register(
                   AllTypes.Pick()
                           .FromAssembly(Assembly.GetAssembly(typeof(ControllersRegistrarMarker)))
                           .If(f => f.Namespace.Contains(".Mappers"))
                           .WithService.FirstNonGenericCoreInterface("WhoCanHelpMe.Web.Controllers"));
        }
    }
}