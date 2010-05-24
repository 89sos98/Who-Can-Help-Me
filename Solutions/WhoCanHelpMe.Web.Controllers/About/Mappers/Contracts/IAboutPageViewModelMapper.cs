namespace WhoCanHelpMe.Web.Controllers.About.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;
    using Cms.Pages;
    using Domain;

    using Framework.Mapper;

    using ViewModels;

    #endregion

    public interface IAboutPageViewModelMapper : IMapper<AboutPage, IList<NewsItem>, AboutPageViewModel>
    {
    }
}