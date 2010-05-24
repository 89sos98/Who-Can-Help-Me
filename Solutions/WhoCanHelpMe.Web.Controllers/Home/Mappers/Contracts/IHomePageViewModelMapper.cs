namespace WhoCanHelpMe.Web.Controllers.Home.Mappers.Contracts
{
    #region Using Directives

    using System.Collections.Generic;
    using Cms.Pages;
    using Domain;

    using Framework.Mapper;

    using ViewModels;

    #endregion

    public interface IHomePageViewModelMapper : IMapper<HomePage, IList<NewsItem>, HomePageViewModel>
    {
    }
}