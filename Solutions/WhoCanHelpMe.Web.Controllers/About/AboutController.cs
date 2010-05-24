namespace WhoCanHelpMe.Web.Controllers.About
{
    #region Using Directives

    using System;
    using System.Web.Mvc;

    using Aspects.Caching;
    using Cms.Pages;
    using Domain.Contracts.Tasks;

    using Framework.Caching;

    using Mappers.Contracts;
    using N2.Web;
    using Shared.ViewModels;

    #endregion

    [Controls(typeof(AboutPage))]
    public class AboutController : N2Controller<AboutPage>
    {
        private readonly IAboutPageViewModelMapper aboutPageViewModelMapper;

        private readonly INewsTasks newsTasks;

        public AboutController(
            INewsTasks newsTasks,
            IAboutPageViewModelMapper aboutPageViewModelMapper)
        {
            this.newsTasks = newsTasks;
            this.aboutPageViewModelMapper = aboutPageViewModelMapper;
        }

        public override ActionResult Index()
        {
            var pageViewModel = this.IndexInner();

            return this.View(pageViewModel);
        }

        // [Cached(CacheName.AdHoc)]
        private PageViewModel IndexInner()
        {
            var developmentTeamBuzz = this.newsTasks.GetDevelopmentTeamBuzz();

            return this.aboutPageViewModelMapper.MapFrom(this.CurrentItem, developmentTeamBuzz);
        }

        public ActionResult DemonstrateErrorHandling()
        {
            throw new NotImplementedException("This action method has purposely been left empty.");
        }
    }
}